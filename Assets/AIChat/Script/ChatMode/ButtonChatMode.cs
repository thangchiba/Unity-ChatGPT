using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(Button))]
    public class ButtonChatMode : MonoBehaviour
    {
        private Button button;
        [SerializeField] private ChatModeState chatModeState;

        public void Awake()
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