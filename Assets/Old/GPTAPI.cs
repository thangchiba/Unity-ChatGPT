using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GPTAPI : MonoBehaviour
{
    [SerializeField] private static int maxSendCount = 10;
    [SerializeField] private static List<MessageModel> listTrain = new();
    [SerializeField] private static List<MessageModel> listMessage = new();
    [SerializeField] private UnityEvent listEvent;
    public delegate void ChatCallback(string response);

    private static void GPTCallback(string response)
    {
        listMessage.Add(new MessageModel(){content = response,role = "assistant"});
    }
    public void Send(string content,ChatCallback callback)
    {
        // Create a new MessageModel with the user role and the specified content
        var newMessage = new MessageModel { role = Role.user.ToString(), content = content };
        listMessage.Add(newMessage);
        // Take the last 10 items from the list
        var sendMessages = new List<MessageModel>(listTrain);
        sendMessages.AddRange(listMessage.TakeLast(maxSendCount).ToList());
        
        var requestBody = new RequestBody
        {
            model = "gpt-3.5-turbo",
            messages = sendMessages
        };
        StartCoroutine(ChatWithAI(requestBody, callback));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private static IEnumerator ChatWithAI(RequestBody requestBody, ChatCallback callback)
    {
        const string url = "https://api.openai.com/v1/chat/completions";
        var bodyJsonString = JsonUtility.ToJson(requestBody);
        var request = new UnityWebRequest(url, "POST");
        var bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        DownloadHandlerScript downloadHandler = new MyCustomScript(callback);
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
        //public MyCustomScript(AsyncCallBack)

        private string deltaContent = "";
        private string dataString = "";
        private readonly ChatCallback callBack;
        private readonly ChatCallback gptCallback;

        public MyCustomScript(ChatCallback callBack)
        {
            this.callBack = callBack;
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
                    callBack(deltaContent);
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

