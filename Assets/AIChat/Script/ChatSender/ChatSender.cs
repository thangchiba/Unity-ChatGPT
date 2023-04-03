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
        public Action<string> OnSubmitChat;
        
        public void SubmitChat()
        {
            ChatManager.Instance.ChatGPT.Send(chatContent.text);
            OnSubmitChat?.Invoke(chatContent.text);
        }
    }
}