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


using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ThangChibaGPT

{
    public class ChatSender : MonoBehaviour
    {
        public TMP_InputField chatContent;
        [SerializeField] private KeyCode submitKey = KeyCode.Return;
        [SerializeField] private UnityEvent onSubmit;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(submitKey)) SubmitChat();
        }

        public void SubmitChat()
        {
            var content = chatContent.text.Trim();
            if (content == "") return;
            ChatManager.Instance.SubmitChat(content);
            onSubmit?.Invoke();
        }
    }
}