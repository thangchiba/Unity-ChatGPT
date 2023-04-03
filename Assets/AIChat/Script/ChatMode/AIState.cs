using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class AIState : ChatModeState
    {
        [SerializeField] private GUIChatController chatSubmitController;

        public override void Setup()
        {
            ChatManager.Instance.ChatGPT.AttachHandler(chatSubmitController);
        }

        public override void Uninstall()
        {
            if (chatSubmitController == null) return;
            ChatManager.Instance.ChatGPT.DetachHandler(chatSubmitController);
        }
    }
}