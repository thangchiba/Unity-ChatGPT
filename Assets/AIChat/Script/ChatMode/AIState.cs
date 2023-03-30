using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class AIState : ChatModeState
    {
        [SerializeField] private GUIChatHandler chatSubmitHandler;
        
        public override void SubmitChat(string content)
        {
            chatSubmitHandler.HandlerSubmitChat(content);
        }

        public override void HandleChat(string content, string sender)
        {
            throw new System.NotImplementedException();
        }

        public override void Setup()
        {
            ChatManager.Instance.ChatGPT.AttachHandler(chatSubmitHandler);
        }

        public override void Uninstall()
        {
            if (chatSubmitHandler == null) return;
            ChatManager.Instance.ChatGPT.DetachHandler(chatSubmitHandler);
        }
    }
}