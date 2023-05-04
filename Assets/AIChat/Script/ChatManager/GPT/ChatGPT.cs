using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

namespace ThangChibaGPT

{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField]
        [Tooltip(
            "Endpoint for request come. You can setup it redirect to openai endpoint or yourself endpoint if you have own api.\n\n" +
            "If you do not have openai account, you can try to use my endpoint is https://api.thangchiba.com/ai/api/v1/chat")]
        private string endPoint = "https://api.openai.com/v1/chat/completions";

        [SerializeField]
        [Tooltip(
            "The Access APIKey you need get from openai homepage.\n" +
            "URL : https://platform.openai.com/account/api-key\n\n" +
            "If you are using my endpoint(thangchiba) you dont need setup access token.")]
        private string accessToken = "Bearer sk-";

        [SerializeField]
        [Tooltip(
            "If you are using openai api access token. You dont need care about this field.\n" +
            "If you are using my endpoint(thangchiba) you need enter freetoken or token i provided.")]
        private string accessKey = "freetoken";

        [SerializeField]
        [Tooltip(
            "GPT Model that decided your output.\n" +
            "You can read more info in here : https://platform.openai.com/docs/models")]
        private EGPTModel egptModel = EGPTModel.GPT35Turbo;

        /// <summary>
        ///     Submit chat to ChatGPT.
        /// </summary>
        /// <param name="chatContent">Chat content that submitted</param>
        /// <param name="controller">Chat Controller that have information of request body and handler response</param>
        public void Send(string chatContent, AIChatController controller)
        {
            controller.OnSubmitChat(chatContent);
            StartCoroutine(ChatWithAI(controller));
        } // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator ChatWithAI(AIChatController controller)
        {
            var sendMessages = new List<AIMessage>(controller.chatStorage.trains);
            sendMessages.AddRange(
                controller.chatStorage.messages.TakeLast(controller.chatStorage.maxSendCount).ToList());
            var requestBody = new AIRequestBody
            {
                model = GetModelName(egptModel),
                messages = sendMessages,
                temperature = controller.chatStorage.temperature,
                max_tokens = controller.chatStorage.maxTokens
            };
            var bodyJsonString = JsonUtility.ToJson(requestBody);
            var request = new UnityWebRequest(endPoint, "POST");
            var bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            DownloadHandlerScript downloadHandler = new HandleChunkResponse(controller);
            using (request)
            {
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = downloadHandler;
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", accessToken);
                request.SetRequestHeader("AccessKey", accessKey);
                yield return request.SendWebRequest();
                if (request.result != UnityWebRequest.Result.Success) Debug.Log(request.error);
            }
        }

        private class HandleChunkResponse : DownloadHandlerScript
        {
            private readonly AIChatController controller;
            private string dataString = "";
            private string deltaContent = "";

            public HandleChunkResponse(AIChatController controller)
            {
                this.controller = controller;
            }

            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                dataString = Encoding.UTF8.GetString(data, 0, dataLength);
                var responseData = dataString.Split(new[] { "data: " }, StringSplitOptions.RemoveEmptyEntries);

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

        private string GetModelName(EGPTModel model)
        {
            switch (model)
            {
                case EGPTModel.GPT35Turbo:
                    return "gpt-3.5-turbo";
                case EGPTModel.GPT4:
                    return "gpt-4";
                default:
                    throw new ArgumentOutOfRangeException("Invalid GPTModel value");
            }
        }
    }
}