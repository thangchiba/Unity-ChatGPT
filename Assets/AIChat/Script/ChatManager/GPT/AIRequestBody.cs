using System;
using System.Collections.Generic;

namespace ThangChibaGPT
{
    [Serializable]
    public class AIRequestBody
    {
        public string model = "gpt-3.5-turbo";
        public List<AIMessage> messages;
        public bool stream = true;
        public float temperature = 0.7f;
        public int max_tokens = 100;
    }
}