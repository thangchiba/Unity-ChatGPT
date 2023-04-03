using System;
using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatMode : MonoBehaviour
    {
        public Action<ChatModeState> OnSetChatMode;
        
        public ChatModeState CurrentState { get; private set; }

        private void OnEnable()
        {
            var defaultChatMode = FindObjectOfType<AIState>();
            if (defaultChatMode != null)
            {
                SetChatMode(defaultChatMode);
            }
        }

        public void SetChatMode(ChatModeState chatModeState)
        {
            CurrentState?.Uninstall();
            CurrentState = chatModeState;
            CurrentState.Setup();
            OnSetChatMode?.Invoke(chatModeState);
        }
    }
}