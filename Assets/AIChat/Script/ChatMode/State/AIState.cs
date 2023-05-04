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

using UnityEngine;

namespace ThangChibaGPT

{
    public class AIState : ChatModeState
    {
        [SerializeField] private GameObject chatLog;
        private GUIChatController guiChatController;

        public void Awake()
        {
            guiChatController = chatLog.GetComponent<GUIChatController>();
        }

        public override void OnSetup()
        {
            chatLog.SetActive(true);
        }

        public override void OnUninstall()
        {
            chatLog.SetActive(false);
        }

        public override void SubmitChat(string content)
        {
            ChatManager.Instance.ChatGPT.Send(content, guiChatController);
        }
    }
}