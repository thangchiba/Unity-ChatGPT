using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    [RequireComponent(typeof(Button))]
    public class ButtonChatMode : MonoBehaviour
    {
        private Button button;
        [SerializeField] private EChatMode chatMode;

        public void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
            ChatManager.Instance.ChatMode.OnSetChatMode.AddListener(HandleChangeChatMode);
        }

        private void HandleChangeChatMode(SChatMode sChatMode)
        {
            if (sChatMode.eChatMode == chatMode)
            {
                button.GetComponent<Image>().color = Color.green;
            }
            else
            {
                button.GetComponent<Image>().color = Color.grey;
            }
        }

        private void OnButtonClick()
        {
            ChatManager.Instance.ChatMode.SetChatMode(chatMode);
        }
    }
}