using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class AIChatHandler : MonoBehaviour
    {
        public AIChatStorage chatStorage;
        public abstract void OnReceiveResponse(string content);
        public abstract void OnReceiveChunkResponse(string content);
    }
}