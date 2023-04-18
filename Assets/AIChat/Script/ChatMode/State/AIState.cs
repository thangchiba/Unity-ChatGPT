using UnityEngine;

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