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

namespace ThangChibaGPT

{
    [RequireComponent(typeof(ChatGPT))]
    [RequireComponent(typeof(ChatMode))]
    public class ChatManager : MonoBehaviour
    {
        public static ChatManager Instance { get; private set; }
        public ChatGPT ChatGPT { get; private set; }
        public ChatMode ChatMode { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                ChatGPT = GetComponent<ChatGPT>();
                ChatMode = GetComponent<ChatMode>();
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SubmitChat(string content)
        {
            ChatMode.CurrentState.SubmitChat(content);
        }
    }
}