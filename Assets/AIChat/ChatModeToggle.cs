using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public enum ChatMode
    {
        PRIVATE,
        GENERAL,
    }
    public class ChatModeToggle : MonoBehaviour
    {
        private ChatMode chatMode;

        public void SetChatMode(ChatMode chatMode)
        {
            chatMode = this.chatMode;
            //TODO Case ChatMode
        }
        
        
    }
}