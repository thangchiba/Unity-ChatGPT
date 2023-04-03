using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class GeneralState : ChatModeState
    {
        [SerializeField] private ChatSender chatSender;
        [SerializeField] private AIChatPlayer aiChatPlayer;
        public override void Setup()
        {
            chatSender.OnSubmitChat += PlayerBark;
            aiChatPlayer.SetEnableTrigger(true);
        }

        public override void Uninstall()
        {
            base.Uninstall();
            chatSender.OnSubmitChat -= PlayerBark;
            aiChatPlayer.SetEnableTrigger(false);
        }

        private void PlayerBark(string content)
        {
            aiChatPlayer.Bark(content);
        }
    }
}