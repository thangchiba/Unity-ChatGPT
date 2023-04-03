using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class AIState : ChatModeState
    {
        [SerializeField] private GameObject chatLog;
        private GUIChatController guiChatController;

        public void Awake()
        {
            guiChatController = chatLog.GetComponent<GUIChatController>();
        }

        public override void Setup()
        {
            chatLog.SetActive(true);
            ChatManager.Instance.ChatGPT.AttachHandler(guiChatController);
        }
        
        public override void Uninstall()
        {
            Debug.Log("Unistall ai state");
            base.Uninstall();
            chatLog.SetActive(false);
        }
    }
}