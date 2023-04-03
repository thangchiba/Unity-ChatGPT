using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class NPCChatHandler : AIChatHandler
    {
        [SerializeField] private BarkController barkController;
        public override void OnReceiveResponse(string content)
        {
            Debug.Log("Npc handle chat : "+content);
        }

        public override void OnReceiveChunkResponse(string content)
        {
            barkController.SetBark(content);
        }

        public override void OnReceiveResponseDone()
        {
            //Delay 5f before hidebark
            Invoke(nameof(HideBark),5f);
        }

        private void HideBark()
        {
            barkController.HideBark();
        }
    }
}