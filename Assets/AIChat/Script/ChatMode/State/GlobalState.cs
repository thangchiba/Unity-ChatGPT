using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class GlobalState : ChatModeState
    {
        [SerializeField] private AIChatPlayer aiChatPlayer;
        public override void OnSetup()
        {
            aiChatPlayer.SetEnableTrigger(true);
        }

        public override void OnUninstall()
        {
            aiChatPlayer.ResetHandler();
            aiChatPlayer.SetEnableTrigger(false);
        }

        private void PlayerBark(string content)
        {
            aiChatPlayer.Bark(content);
        }

        public override void SubmitChat(string content)
        {
            PlayerBark(content);
            aiChatPlayer.GetListHandler().ForEach(controller=>ChatManager.Instance.ChatGPT.Send(content,controller));
        }
    }
}