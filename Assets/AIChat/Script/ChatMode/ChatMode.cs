using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class ChatMode : MonoBehaviour
    {
        public ChatModeState CurrentState { get; private set; }

        private void OnEnable()
        {
            var defaultChatMode = FindObjectOfType<AIState>();
            if (defaultChatMode != null)
            {
                SetChatMode(defaultChatMode);
            }
        }

        public void SetChatMode(ChatModeState chatModeState)
        {
            chatModeState.Uninstall();
            this.CurrentState = chatModeState;
            chatModeState.Setup();
        }
    }
}