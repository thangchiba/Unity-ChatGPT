using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class AIChatController : MonoBehaviour
    {
        public AIChatStorage chatStorage;

        protected void AddMessage(Role role, string content)
        {
            chatStorage.messages.Add(new AIMessage(role,content));
        }

        public virtual void OnSubmitChat(string content)
        {
            AddMessage(Role.user,content);
        }

        public virtual void OnReceiveResponse(string content)
        {
            AddMessage(Role.assistant,content);
        }
        public abstract void OnReceiveChunkResponse(string content);
    }
}