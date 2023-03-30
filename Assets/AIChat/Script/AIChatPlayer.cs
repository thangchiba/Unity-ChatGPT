using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatPlayer : MonoBehaviour
    {
        //TODO Add Bark class
        [SerializeField] private AIChatManager chatManager;
        private void OnTriggerEnter(Collider other)
        {
            var npcChat = other.GetComponent<NPCChatHandler>();
            if (npcChat != null)
            {
                Debug.Log("Triggered with "+other.gameObject.name);
                chatManager.AttachHandler(npcChat);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var npcChat = other.GetComponent<NPCChatHandler>();
            if (npcChat != null)
            {
                Debug.Log("Exit trigger with "+other.gameObject.name);
                chatManager.DetachHandler(npcChat);
            }
        }

        public void OnChatSubmit()
        {
            //Handle event when chat submitted
            throw new System.NotImplementedException();
        }
    }
}