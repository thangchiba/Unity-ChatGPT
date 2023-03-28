using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatSender : MonoBehaviour
    {
        public TextMeshProUGUI chatContent;
        public Button submitChat;
        private ChatMode chatMode;


        public void SetChatMode(ChatMode chatMode)
        {
            this.chatMode = chatMode;
        }
        // private void OnEnable()
        // {
        //     submitChat.onClick.AddListener(SubmitChat);
        // }

        public void SubmitChat()
        {
            chatMode.SubmitChat(chatContent.text);
        }
    }
}