using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    [CreateAssetMenu(fileName = "Storage", menuName = "AIChat", order = 0)]
    public class AIChatStorage : ScriptableObject
    {
        public bool clearHistoryOnStart = true;
        [Range(0, 10)] public int maxSendCount = 6;
        [Range(0f, 2f)] public float temperature = 0.7f;
        [Range(10, 4000)] public int maxTokens = 100;
        public List<AIMessage> trains;
        public List<AIMessage> messages;

        public void OnEnable()
        {
            if (clearHistoryOnStart) messages = new List<AIMessage>();
        }
    }
}