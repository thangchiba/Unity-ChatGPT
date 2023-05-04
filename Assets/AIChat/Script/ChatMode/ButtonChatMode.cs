/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

using UnityEngine;
using UnityEngine.UI;

namespace ThangChibaGPT

{
    [RequireComponent(typeof(Button))]
    public class ButtonChatMode : MonoBehaviour
    {
        [SerializeField] private EChatMode chatMode;
        private Button button;

        public void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
            ChatManager.Instance.ChatMode.OnSetChatMode.AddListener(HandleChangeChatMode);
        }

        private void HandleChangeChatMode(SChatMode sChatMode)
        {
            if (sChatMode.eChatMode == chatMode)
                button.GetComponent<Image>().color = Color.green;
            else
                button.GetComponent<Image>().color = Color.grey;
        }

        private void OnButtonClick()
        {
            ChatManager.Instance.ChatMode.SetChatMode(chatMode);
        }
    }
}