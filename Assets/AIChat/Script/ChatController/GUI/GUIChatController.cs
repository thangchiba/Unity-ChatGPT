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

using UnityEngine;
using UnityEngine.UI;

namespace ThangChibaGPT
{
    [RequireComponent(typeof(ScrollRect))]
    public class GUIChatController : AIChatController
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Frame frameChat;
        private Message chunkMessage;

        public override void OnSubmitChat(string content)
        {
            AddMessage(Role.user, content);
            frameChat.AddChatMessage(content, "user");
            chunkMessage = frameChat.AddChatMessage("", "assistant");
        }

        public override void OnReceiveChunkResponse(string content)
        {
            chunkMessage.SetContent(content);
            ScrollToBottom();
        }


        private void ScrollToBottom()
        {
            // Set the vertical normalized position to 0
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}