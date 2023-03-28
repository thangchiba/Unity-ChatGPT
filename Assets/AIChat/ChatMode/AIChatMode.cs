using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class AIChatMode : ChatMode
    {
        [SerializeField] private GUIChatHandler chatSubmitHandler;
        [SerializeField] private AIChatManager chatManager;
        
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
            chatManager.AttachHandler(chatSubmitHandler);
        }

        public override void Uninstall()
        {
            chatManager.DetachHandler(chatSubmitHandler);
        }
    }
}