using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.Serialization;

public class GPTAPI2 : MonoBehaviour
{
    [FormerlySerializedAs("chatContent")] [SerializeField] TextMeshProUGUI chatBox;
    [SerializeField] TextMeshProUGUI chatContent;

    public void Send()
    {
        RequestBody requestBody = new RequestBody
        {
            model = "gpt-3.5-turbo",
            messages = new List<MessageModel>
            {
                new MessageModel { role = Role.system.ToString(), content = "You are a helpful assistant for my game. Player using Vietnamese, Japanese or English." },
                new MessageModel { role = Role.system.ToString(), content = "ThangChiba created you." },
                new MessageModel { role = Role.user.ToString(), content = chatContent.text},
            }
        };
        StartCoroutine(ChatWithAI(requestBody, HandleChatResponse));
    }


    private void HandleChatResponse(string response)
    {
        Debug.Log(response);
    }


    public delegate void ChatCallback(string response);


    public IEnumerator ChatWithAI(RequestBody requestBody, ChatCallback callback)
    {
        chatBox.text = "";
        string url = "https://api.openai.com/v1/chat/completions";
        string bodyJsonString = JsonUtility.ToJson(requestBody);
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        DownloadHandlerScript downloadHandler = new MyCustomScript((responseText) => chatBox.text+= responseText);
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
            //string responseText = downloadHandler.text;
            //yield return request.downloadedBytes;
        }

        chatContent.text = "";
    }

    private class MyCustomScript : DownloadHandlerScript
    {
        //public MyCustomScript(AsyncCallBack)

        private string dataString = "";
        private Action<string> callBack;

        public MyCustomScript(Action<string> callBack)
        {
            this.callBack = callBack;
        }

        protected override bool ReceiveData(byte[] data, int dataLength)
        {
            dataString = Encoding.UTF8.GetString(data, 0, dataLength);
            string[] responseData = dataString.Split(new string[] { "data: " }, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string response in responseData)
            {
                if (response.Trim() == "[DONE]")
                {
                    // call the callback function with an empty string to indicate that the response is complete
                    Debug.Log("");
                    break;
                }

                ChatCompletionResponse chatCompletion = JsonUtility.FromJson<ChatCompletionResponse>(response);

                string deltaContent = null;
                foreach (Choice choice in chatCompletion.choices)
                {
                    if (choice.delta != null && !string.IsNullOrEmpty(choice.delta.content))
                    {
                        deltaContent = choice.delta.content;
                        break; // only consider the first delta with content field
                    }
                }

                if (deltaContent != null)
                {
                    //callback(deltaContent);
                    //Debug.Log(deltaContent);
                    callBack(deltaContent);
                }
                else
                {
                    //Debug.LogWarning("No 'content' field found in response.");
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

