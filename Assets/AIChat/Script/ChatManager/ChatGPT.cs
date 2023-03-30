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
        private static List<AIChatHandler> listAIChatHandler = new List<AIChatHandler>();
        

        public void AttachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Add(handler);
        }
        
        public void DetachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Remove(handler);
        }
        
        public void Send(AIChatStorage chatStorage)
        {
            var sendMessages = new List<AIMessage>(chatStorage.trains);
            sendMessages.AddRange(chatStorage.messages.TakeLast(chatStorage.maxSendCount).ToList());
            var requestBody = new AIRequestBody
            {
                model = "gpt-3.5-turbo",
                messages = sendMessages,
                temperature = chatStorage.temperature,
            };
            StartCoroutine(ChatWithAI(requestBody));
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator ChatWithAI(AIRequestBody requestBody)
        {
            // const string url = "https://api.openai.com/v1/chat/completions";
            var bodyJsonString = JsonUtility.ToJson(requestBody);
            var request = new UnityWebRequest(endPoint, "POST");
            var bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            DownloadHandlerScript downloadHandler = new HandleChunkResponse();
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
        
                // var s = request.downloadHandler.deltaContent;
                //string responseText = downloadHandler.text;
                //yield return request.downloadedBytes;
            }
        }
        
        private class HandleChunkResponse : DownloadHandlerScript
        {
            private string deltaContent = "";
            private string dataString = "";
        
            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                dataString = Encoding.UTF8.GetString(data, 0, dataLength);
                var responseData = dataString.Split(new string[] { "data: " }, System.StringSplitOptions.RemoveEmptyEntries);
        
                foreach (var response in responseData)
                {
                    if (response.Trim() == "[DONE]")
                    {
                        // call the callback function with an empty string to indicate that the response is complete
                        Debug.Log("Done");
                        listAIChatHandler.ForEach(x =>
                        {
                            x.OnReceiveResponse(deltaContent);
                        });
                        break;
                    }
        
                    var chatCompletion = JsonUtility.FromJson<ChatCompletionResponse>(response);
        
                    foreach (var choice in chatCompletion.choices)
                    {
                        if (choice.delta == null || string.IsNullOrEmpty(choice.delta.content)) continue;
                        deltaContent += choice.delta.content;
                        listAIChatHandler.ForEach(x =>
                        {
                            x.OnReceiveChunkResponse(deltaContent);
                        });
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