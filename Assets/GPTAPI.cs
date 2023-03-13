using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
public class GPTAPI : MonoBehaviour
{

    //public void Send()
    //{
    //    RequestBody requestBody = new RequestBody
    //    {
    //        model = "gpt-3.5-turbo",
    //        messages = new List<MessageModel>
    //        {
    //            new MessageModel { role = Role.system.ToString(), content = "You are a helpful assistant for my game. Player using Vietnamese, Japanese or English." },
    //            new MessageModel { role = Role.system.ToString(), content = "ThangChiba created you." },
    //            new MessageModel { role = Role.user.ToString(), content = "Hello how are you? do you need me?" },
    //        }
    //    };
    //    StartCoroutine(CallAPI(requestBody));
    //}

    //IEnumerator CallAPI(RequestBody requestBody)
    //{
    //    // Send the request to the OpenAI chat API
    //    yield return StartCoroutine(ChatWithAI(requestBody, response =>
    //    {
    //        // Handle the response from the API
    //        Debug.Log(response);
    //    }));
    //}

    //public delegate void ChatCallback(string response);

    //public IEnumerator ChatWithAI(RequestBody requestBody, ChatCallback callback)
    //{
    //    string url = "https://api.openai.com/v1/chat/completions";
    //    string bodyJsonString = JsonUtility.ToJson(requestBody);
    //    var request = new UnityWebRequest(url, "POST");
    //    using (request)
    //    {
    //        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
    //        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //        request.downloadHandler = new DownloadHandlerBuffer();
    //        request.SetRequestHeader("Content-Type", "application/json");
    //        request.SetRequestHeader("Authorization", "Bearer " + "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");
    //        yield return request.SendWebRequest();
    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        //else
    //        //{
    //        //    //ResponseModel result = JsonUtility.FromJson<ResponseModel>(request.downloadHandler.text);
    //        //    Debug.Log(request.downloadHandler.text);
    //        //    //callback(result.replyContent.Replace(System.Environment.NewLine, ""), result.replyLanguage);
    //        //}

    //        else
    //        {
    //            DownloadHandlerBuffer downloadHandler = request.downloadHandler as DownloadHandlerBuffer;
    //            string responseText = downloadHandler.text;
    //            Debug.Log(responseText);

    //            string[] responseData = responseText.Split(new string[] { "data: " }, System.StringSplitOptions.RemoveEmptyEntries);

    //            foreach (string response in responseData)
    //            {
    //                if (response.Trim() == "[DONE]")
    //                {
    //                    // call the callback function with an empty string to indicate that the response is complete
    //                    callback("");
    //                    break;
    //                }

    //                ChatCompletionResponse chatCompletion = JsonUtility.FromJson<ChatCompletionResponse>(response);

    //                string deltaContent = null;
    //                foreach (Choice choice in chatCompletion.choices)
    //                {
    //                    if (choice.delta != null && !string.IsNullOrEmpty(choice.delta.content))
    //                    {
    //                        deltaContent = choice.delta.content;
    //                        break; // only consider the first delta with content field
    //                    }
    //                }

    //                if (deltaContent != null)
    //                {
    //                    callback(deltaContent);
    //                    Debug.Log(deltaContent);
    //                }
    //                else
    //                {
    //                    //Debug.LogWarning("No 'content' field found in response.");
    //                }
    //            }
    //        }
    //    }
    //}
}


//[System.Serializable]
//public class Choice
//{
//    public Delta delta;
//    public int index;
//    public string finish_reason;
//}

//[System.Serializable]
//public class Delta
//{
//    public string role;
//    public string content;
//}

//[System.Serializable]
//public class ChatCompletionResponse
//{
//    public string id;
//    public string @object;
//    public long created;
//    public string model;
//    public Choice[] choices;
//}

