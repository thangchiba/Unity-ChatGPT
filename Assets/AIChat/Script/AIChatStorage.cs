
using System;
using System.Collections.Generic;
using UnityEngine;


namespace MMORPG.UI.AIChat
{
    [CreateAssetMenu(fileName = "Storage", menuName = "AIChat", order=0)]
    public class AIChatStorage : ScriptableObject
    {
        public bool clearHistoryOnStart = true;
        public int maxSendCount = 10;
        [Range(0f, 2f)] public float temperature = 0.7f;
        public List<AIMessage> trains;
        public List<AIMessage> messages;

        public void OnEnable()
        {
            if (clearHistoryOnStart) messages = new List<AIMessage>();
        }
    }
}