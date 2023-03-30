using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class NPCChatHandler : AIChatHandler
    {
        public override void OnReceiveResponse(string content)
        {
            Debug.Log("Npc handle chat : "+content);
        }

        public override void OnReceiveChunkResponse(string content)
        {
        }
    }
}