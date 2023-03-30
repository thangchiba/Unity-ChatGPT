using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatPlayer : MonoBehaviour
    {
        //TODO Add Bark class
        private void OnTriggerEnter(Collider other)
        {
            var npcChat = other.GetComponent<NPCChatHandler>();
            if (npcChat != null)
            {
                Debug.Log("Triggered with "+other.gameObject.name);
                ChatManager.Instance.ChatGPT.AttachHandler(npcChat);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var npcChat = other.GetComponent<NPCChatHandler>();
            if (npcChat != null)
            {
                Debug.Log("Exit trigger with "+other.gameObject.name);
                ChatManager.Instance.ChatGPT.DetachHandler(npcChat);
            }
        }

        public void OnChatSubmit()
        {
            //Handle event when chat submitted
            throw new System.NotImplementedException();
        }
    }
}