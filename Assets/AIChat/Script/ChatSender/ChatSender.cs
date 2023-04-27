using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MMORPG.UI.AIChat
{
    public class ChatSender : MonoBehaviour
    {
        public TMP_InputField chatContent;
        [SerializeField] KeyCode submitKey = KeyCode.Return;
        [SerializeField] private UnityEvent onSubmit; 
        
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
            ChatManager.Instance.SubmitChat(content);
            onSubmit?.Invoke();
        }
    }
}