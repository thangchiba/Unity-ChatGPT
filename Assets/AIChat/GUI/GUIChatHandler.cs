using UnityEngine;
using UnityEngine.Networking.Match;

namespace MMORPG.UI.AIChat
{
    public class GUIChatHandler : AIChatHandler
    {
        [SerializeField] private Frame frameChat;
        private Message receiveMessage;

        public void HandlerSubmitChat(string content)
        {
            base.SubmitChat(content);
            frameChat.AddChatMessage(content, "user");
            receiveMessage = frameChat.AddChatMessage("", "assistant");
        }
        
        public override void OnReceiveResponse(string content)
        {
            receiveMessage.SetContent(content);
        }

        public override void OnReceiveChunkResponse(string content)
        {
            receiveMessage.SetContent(content);
        }
    }
}