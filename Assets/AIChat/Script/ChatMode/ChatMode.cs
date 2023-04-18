using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.UI.AIChat
{
    public class ChatMode : MonoBehaviour
    {
        [SerializeField] private List<SChatMode> listChatMode;
        public UnityEvent<SChatMode> OnSetChatMode;

        public ChatModeState CurrentState { get; private set; }

        private void Start()
        {
            SetupDefaultChatMode();
        }

        public void SetChatMode(EChatMode eChatMode)
        {
            CurrentState?.OnUninstall();
            var sChatMode = GetChatMode(eChatMode);
            CurrentState = sChatMode.chatState;
            CurrentState.OnSetup();
            OnSetChatMode?.Invoke(sChatMode);
        }

        private SChatMode GetChatMode(EChatMode eChatMode)
        {
            return listChatMode.Find(x => x.eChatMode == eChatMode);
        }

        private void SetupDefaultChatMode()
        {
            SetChatMode(listChatMode[0].eChatMode);
        }
    }
}