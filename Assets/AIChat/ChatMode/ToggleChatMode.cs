using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(ChatMode))]
    public class ToggleChatMode : MonoBehaviour
    {
        [SerializeField] private ChatSender chatSender;
        private Button button;
        [SerializeField] private ChatMode chatMode;

        public void OnEnable()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            chatSender.SetChatMode(chatMode);
        }
    }
}