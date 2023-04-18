using System;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class NpcChatController : AIChatController
    {
        private BarkController barkController;

        private void Awake()
        {
            barkController = GetComponentInChildren<BarkController>();
        }

        public override void OnReceiveChunkResponse(string content)
        {
            barkController.SetBark(content);
        }
    }
}