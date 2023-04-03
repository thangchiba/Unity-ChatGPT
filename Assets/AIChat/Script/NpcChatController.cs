using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class NpcChatController : AIChatController
    {
        [SerializeField] private BarkController barkController;
        public override void OnReceiveResponse(string content)
        {
            base.OnReceiveResponse(content);
            Debug.Log("Npc handle chat : "+content);
        }

        public override void OnReceiveChunkResponse(string content)
        {
            barkController.SetBark(content);
        }
    }
}