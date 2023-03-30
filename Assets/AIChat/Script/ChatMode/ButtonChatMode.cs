using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(ChatMode))]
    public class ButtonChatMode : MonoBehaviour
    {
        
        private Button button;
        [SerializeField] private ChatMode chatMode;
        private ChatModeContext _chatModeContext;

        public void OnEnable()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
            _chatModeContext = GetComponentInParent<ChatModeContext>();
        }

        private void OnButtonClick()
        {
            _chatModeContext.SetChatMode(chatMode);
        }
    }
}