using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class AIChatMode : ChatMode
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
    }
}