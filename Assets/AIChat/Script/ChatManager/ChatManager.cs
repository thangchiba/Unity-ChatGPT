using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class ChatManager : MonoBehaviour
    {
        public static ChatManager Instance { get; private set; }
        public ChatGPT ChatGPT { get; private set; }
        public ChatMode ChatMode { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                ChatGPT = gameObject.AddComponent<ChatGPT>();
                ChatMode = gameObject.AddComponent<ChatMode>();
                SetupDefaultChatMode();
            }
        }

        private void SetupDefaultChatMode()
        {
            var defaultChatMode = FindObjectOfType<AIState>();
            if (defaultChatMode != null && ChatMode.CurrentState == null)
            {
                ChatMode.SetChatMode(defaultChatMode);
            }
        }

        public void SubmitChat(string content)
        {
            ChatMode.CurrentState.SubmitChat(content);
        }
    }
}