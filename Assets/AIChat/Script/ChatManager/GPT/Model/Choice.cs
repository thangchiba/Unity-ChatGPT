using System;

namespace MMORPG.UI.AIChat.Model
{
    [Serializable]
    public class Choice
    {
        public Delta delta;
        public int index;
        public string finish_reason;
    }
}