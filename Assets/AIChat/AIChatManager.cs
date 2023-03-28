using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatManager : MonoBehaviour
    {
        private static AIChatManager instance;
        private static List<AIChatHandler> listAIChatHandler = new List<AIChatHandler>();
        public static AIChatManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AIChatManager();
                }
                return instance;
            }
        }

        public void AttachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Add((handler));
        }
        
        public void DetachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Remove((handler));
        }
        
        public void Send(AIChatStorage chatStorage)
        {
            
            var requestBody = new AIRequestBody
            {
                model = "gpt-3.5-turbo",
                messages = chatStorage.messages
            };
            StartCoroutine(ChatWithAI(requestBody));
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private static IEnumerator ChatWithAI(AIRequestBody requestBody)
        {
            const string url = "https://api.openai.com/v1/chat/completions";
            var bodyJsonString = JsonUtility.ToJson(requestBody);
            var request = new UnityWebRequest(url, "POST");
            var bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            DownloadHandlerScript downloadHandler = new MyCustomScript();
            using (request)
            {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = downloadHandler;
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization",
                    "Bearer " + "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");
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
        
        private class MyCustomScript : DownloadHandlerScript
        {
            private string deltaContent = "";
            private string dataString = "";
        
            public MyCustomScript()
            {
            }
        
            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                dataString = Encoding.UTF8.GetString(data, 0, dataLength);
                var responseData = dataString.Split(new string[] { "data: " }, System.StringSplitOptions.RemoveEmptyEntries);
        
                foreach (var response in responseData)
                {
                    if (response.Trim() == "[DONE]")
                    {
                        // call the callback function with an empty string to indicate that the response is complete
                        Debug.Log("");
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
                    listAIChatHandler.ForEach(x =>
                    {
                        x.OnReceiveResponse(deltaContent);
                    });
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