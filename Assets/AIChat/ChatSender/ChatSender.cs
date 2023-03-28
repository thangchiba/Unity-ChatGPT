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
        [SerializeField] private ToggleChatMode toggleChatMode;
        
        public void SubmitChat()
        {
            toggleChatMode.GetChatMode().SubmitChat(chatContent.text);
        }
    }
}