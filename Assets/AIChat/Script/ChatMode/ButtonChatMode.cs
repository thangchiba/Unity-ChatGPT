using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ButtonChatMode : MonoBehaviour
    {
        private Button button;
        [SerializeField] private ChatModeState chatModeState;

        public void OnEnable()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ChatManager.Instance.ChatMode.SetChatMode(chatModeState);
        }
    }
}