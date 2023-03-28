using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(ChatMode))]
    public class ButtonChatMode : MonoBehaviour
    {
        
        private Button button;
        [SerializeField] private ChatMode chatMode;
        private ToggleChatMode toggleChatMode;

        public void OnEnable()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
            toggleChatMode = GetComponentInParent<ToggleChatMode>();
        }

        private void OnButtonClick()
        {
            toggleChatMode.SetChatMode(chatMode);
        }
    }
}