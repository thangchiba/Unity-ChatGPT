using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public class ChatSender : MonoBehaviour
    {
        public TMP_InputField chatContent;
        public Action<string> OnSubmitChat;
        [SerializeField] KeyCode submitKey = KeyCode.Return;
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(submitKey))
            {
                SubmitChat();
            }
        }
        public void SubmitChat()
        {
            if (chatContent.text.Trim() == "") return; 
            ChatManager.Instance.ChatGPT.Send(chatContent.text);
            OnSubmitChat?.Invoke(chatContent.text);
            chatContent.text = "";
            chatContent.Select();
        }
    }
}