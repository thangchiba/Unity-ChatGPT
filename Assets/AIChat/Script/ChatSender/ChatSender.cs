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
        [SerializeField] KeyCode submitKey = KeyCode.Return;
        
        private List<IChatHandler> listHandler = new List<IChatHandler>();
        
        public void AttachHandler(IChatHandler handler)
        {
            listHandler.Add(handler);
        }
        
        public void DetachHandler(IChatHandler handler)
        {
            listHandler.Remove(handler);
        }
        
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
            string content = chatContent.text.Trim();
            if (content == "") return; 
            listHandler.ForEach(handler=>handler.OnChatSubmit(content));
            ChatManager.Instance.SubmitChat(content);
            chatContent.text = "";
            chatContent.Select();
        }
    }
}