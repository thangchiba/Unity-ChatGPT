/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

using System.Collections.Generic;
using UnityEngine;

namespace ThangChibaGPT

{
    [RequireComponent(typeof(SphereCollider))]
    public class AIChatPlayer : MonoBehaviour
    {
        private BarkController barkController;
        private SphereCollider collider;
        private List<AIChatController> listAIChatController;

        private void Awake()
        {
            collider = GetComponent<SphereCollider>();
            barkController = GetComponentInChildren<BarkController>();
            listAIChatController = new List<AIChatController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var npcChat = other.GetComponent<NpcChatController>();
            if (npcChat != null) listAIChatController.Add(npcChat);
        }

        private void OnTriggerExit(Collider other)
        {
            var npcChat = other.GetComponent<NpcChatController>();
            if (npcChat != null) listAIChatController.Remove(npcChat);
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
            barkController?.SetBark(content);
        }

        public void SetEnableTrigger(bool enableTrigger)
        {
            collider.enabled = enableTrigger;
        }
    }
}