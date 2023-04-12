using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class GeneralState : ChatModeState
    {
        [SerializeField] private AIChatPlayer aiChatPlayer;
        public override void OnSetup()
        {
            Debug.Log("setup general state");
            aiChatPlayer.SetEnableTrigger(true);
        }

        public override void OnUninstall()
        {
            aiChatPlayer.ResetHandler();
            aiChatPlayer.SetEnableTrigger(false);
        }

        public void PlayerBark(string content)
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