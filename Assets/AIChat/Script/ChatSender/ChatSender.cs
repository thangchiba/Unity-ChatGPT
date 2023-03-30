using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatSender : MonoBehaviour
    {
        public TextMeshProUGUI chatContent;
        public Button submitChat;
        
        public void SubmitChat()
        {
            ChatManager.Instance.ChatMode.CurrentState.SubmitChat(chatContent.text);
        }
    }
}