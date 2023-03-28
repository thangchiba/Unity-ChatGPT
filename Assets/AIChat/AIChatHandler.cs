using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class AIChatHandler : MonoBehaviour
    {
        public AIChatStorage chatStorage;
        [SerializeField] private AIChatManager chatManager;
        
        public void SubmitChat(string content)
        {
            Debug.Log("Submit Chat On Base");
            chatStorage.messages.Add(new AIMessage(Role.user,content));
            chatManager.Send(chatStorage);
        }
        
        public abstract void OnReceiveResponse(string content);
        public abstract void OnReceiveChunkResponse(string content);
    }
}