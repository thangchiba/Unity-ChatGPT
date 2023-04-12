using System;
using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(BarkController))]
    public class AIChatPlayer : MonoBehaviour
    {
        private BarkController barkController;
        private SphereCollider collider;
        private List<AIChatController> listAIChatController;

        private void Awake()
        {
            collider = GetComponent<SphereCollider>();
            barkController = GetComponent<BarkController>();
            listAIChatController = new List<AIChatController>();
        }

        public List<AIChatController> GetListHandler()
        {
            return listAIChatController;
        }
        
        public void ResetHandler()
        {
            listAIChatController = new List<AIChatController>();
        }

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
                listAIChatController.Add(npcChat);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var npcChat = other.GetComponent<NpcChatController>();
            if (npcChat != null)
            {
                Debug.Log("Exit trigger with "+other.gameObject.name);
                listAIChatController.Remove(npcChat);
            }
        }

    }
}