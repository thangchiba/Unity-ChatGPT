using System;
using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatMode : MonoBehaviour
    {
        public Action<ChatModeState> OnSetChatMode;
        
        public ChatModeState CurrentState { get; private set; }

        private void Awake()
        {
            SetupDefaultChatMode();
        }

        public void SetChatMode(ChatModeState chatModeState)
        {
            CurrentState?.OnUninstall();
            CurrentState = chatModeState;
            CurrentState.OnSetup();
            OnSetChatMode?.Invoke(chatModeState);
        }

        private void SetupDefaultChatMode()
        {
            var defaultChatMode = FindObjectOfType<AIState>();
            if (defaultChatMode != null && CurrentState == null)
            {
                SetChatMode(defaultChatMode);
            }
        }
    }
}