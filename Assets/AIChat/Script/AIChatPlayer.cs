using System;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatPlayer : MonoBehaviour
    {
        [SerializeField] private BarkController barkController;
        [SerializeField] private SphereCollider collider;
        
        public void Bark(string content)
        {
            barkController.SetBark(content);
        }

        public void SetEnableTrigger(bool enableTrigger)
        {
            collider.enabled = enableTrigger;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var npcChat = other.GetComponent<NpcChatController>();
            if (npcChat != null)
            {
                Debug.Log("Triggered with "+other.gameObject.name);
                ChatManager.Instance.ChatGPT.AttachHandler(npcChat);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var npcChat = other.GetComponent<NpcChatController>();
            if (npcChat != null)
            {
                Debug.Log("Exit trigger with "+other.gameObject.name);
                ChatManager.Instance.ChatGPT.DetachHandler(npcChat);
            }
        }

    }
}