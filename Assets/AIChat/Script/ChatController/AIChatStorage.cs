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

using System.Collections.Generic;
using UnityEngine;

namespace ThangChibaGPT

{
    [CreateAssetMenu(fileName = "Storage", menuName = "AIChat", order = 0)]
    public class AIChatStorage : ScriptableObject
    {
        [Tooltip("Clear history every time game start.")]
        public bool clearHistoryOnStart = true;

        [Tooltip("Max send count is number of message in history of storage.\n" +
                 "It is memory of ai.\n\n" +
                 "Notice : if you use too much, it cost token and make your bill be giant.")]
        [Range(0, 10)]
        public int maxSendCount = 6;

        [Tooltip("It is randomless value of ai.")] [Range(0f, 2f)]
        public float temperature = 0.7f;

        [Tooltip("It is max token that ai can generate.")] [Range(10, 4000)]
        public int maxTokens = 100;

        public List<AIMessage> trains;
        public List<AIMessage> messages;

        public void OnEnable()
        {
            if (clearHistoryOnStart) messages = new List<AIMessage>();
        }
    }
}