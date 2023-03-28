using UnityEngine;
using UnityEngine.Networking.Match;

namespace MMORPG.UI.AIChat
{
    public class GUIChatHandler : AIChatHandler
    {
        [SerializeField] private Frame frameChat;

        public void HandlerSubmitChat(string content)
        {
            base.SubmitChat(content);
            frameChat.AddChatMessage(content, "user");
        }
        
        public override void OnReceiveResponse(string content)
        {
            throw new System.NotImplementedException();
        }

        public override void OnReceiveChunkResponse(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}