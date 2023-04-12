using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class GUIChatController : AIChatController
    {
        [SerializeField] private Frame frameChat;
        private Message chunkMessage;

        public override void OnSubmitChat(string content)
        {
            AddMessage(Role.user,content);
            frameChat.AddChatMessage(content, "user");
            chunkMessage = frameChat.AddChatMessage("", "assistant");
        }

        public override void OnReceiveChunkResponse(string content)
        {
            chunkMessage.SetContent(content);
        }
    }
}