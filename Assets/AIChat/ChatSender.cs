using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace MMORPG.UI.AIChat
{
    public class ChatSender : MonoBehaviour
    {
        private List<IChatHandler> listChatHandler = new();

        public void Attach(IChatHandler chatHandler)
        {
            
        }

        public void Detach(IChatHandler chatHandler)
        {
        }

        public TextMeshProUGUI chatContent;

        public Button submitChat;

        public void SubmitChat()
        {
            listChatHandler.ForEach(chatHandler =>
            {
                chatHandler.OnChatSubmit();
            });
        }
    }
}