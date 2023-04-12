using System;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace MMORPG.UI.AIChat
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private string endPoint = "https://api.openai.com/v1/chat/completions";
        [SerializeField] private string accessToken = "Bearer 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";
        [SerializeField] private string accessKey = "freetoken";
        public void Send(string chatContent, AIChatController controller)
        {
            controller.OnSubmitChat(chatContent);
            StartCoroutine(ChatWithAI(controller));
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator ChatWithAI(AIChatController controller)
        {
            var sendMessages = new List<AIMessage>(controller.chatStorage.trains);
            sendMessages.AddRange(controller.chatStorage.messages.TakeLast(controller.chatStorage.maxSendCount).ToList());
            var requestBody = new AIRequestBody
            {
                model = "gpt-3.5-turbo",
                messages = sendMessages,
                temperature = controller.chatStorage.temperature,
            };
            var bodyJsonString = JsonUtility.ToJson(requestBody);
            var request = new UnityWebRequest(endPoint, "POST");
            var bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            DownloadHandlerScript downloadHandler = new HandleChunkResponse(controller);
            using (request)
            {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = downloadHandler;
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization",accessToken);
                request.SetRequestHeader("AccessKey",accessKey);
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(request.error);
                }
            }
        }
        
        private class HandleChunkResponse : DownloadHandlerScript
        {
            private string deltaContent = "";
            private string dataString = "";
            private AIChatController controller;

            public HandleChunkResponse(AIChatController controller)
            {
                this.controller = controller;
            }
        
            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                dataString = Encoding.UTF8.GetString(data, 0, dataLength);
                var responseData = dataString.Split(new string[] { "data: " }, System.StringSplitOptions.RemoveEmptyEntries);
        
                foreach (var response in responseData)
                {
                    if (response.Trim() == "[DONE]")
                    {
                        controller.OnReceiveResponse(deltaContent);
                        break;
                    }
        
                    var chatCompletion = JsonUtility.FromJson<ChatCompletionResponse>(response);
        
                    foreach (var choice in chatCompletion.choices)
                    {
                        if (choice.delta == null || string.IsNullOrEmpty(choice.delta.content)) continue;
                        deltaContent += choice.delta.content;
                        controller.OnReceiveChunkResponse(deltaContent);
                        break; // only consider the first delta with content field
                    }
                }
                return base.ReceiveData(data, dataLength);
            }
        }
    }

    [System.Serializable]
    public class Choice
    {
        public Delta delta;
        public int index;
        public string finish_reason;
    }

    [System.Serializable]
    public class Delta
    {
        public string role;
        public string content;
    }

    [System.Serializable]
    public class ChatCompletionResponse
    {
        public string id;
        public string @object;
        public long created;
        public string model;
        public Choice[] choices;
    
    }
}