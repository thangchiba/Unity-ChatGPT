using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class ChatModeState : MonoBehaviour
    {
        public abstract void SubmitChat(string content);
        public abstract void HandleChat(string content,string sender);

        public abstract void Setup();
        public abstract void Uninstall();
    }
}