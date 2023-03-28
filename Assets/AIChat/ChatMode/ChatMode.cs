using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class ChatMode : MonoBehaviour
    {
        public abstract void SubmitChat(string content);
        public abstract void HandleChat(string content,string sender);
    }
}