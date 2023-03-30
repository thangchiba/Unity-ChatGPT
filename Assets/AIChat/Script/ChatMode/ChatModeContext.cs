using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatModeContext : MonoBehaviour
    {
        private ChatMode chatMode;

        public ChatMode GetChatMode() => chatMode;

        public void SetChatMode(ChatMode chatMode)
        {
            chatMode.Uninstall();
            this.chatMode = chatMode;
            chatMode.Setup();
        }
    }
}