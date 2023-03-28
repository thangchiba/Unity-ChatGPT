using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class PrivateChatMode : ChatMode
    {
        public override void SubmitChat(string content)
        {
            Debug.Log("Hello Private Chat");
        }

        public override void HandleChat(string content, string sender)
        {
            throw new System.NotImplementedException();
        }
    }
}