using System;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
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
                ChatGPT = gameObject.AddComponent<ChatGPT>();
                ChatMode = gameObject.AddComponent<ChatMode>();
            }
        }

    }
}