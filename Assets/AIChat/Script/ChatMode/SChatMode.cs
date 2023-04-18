using System;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    [Serializable]
    public struct SChatMode
    {
        public EChatMode eChatMode;
        public ChatModeState chatState;
    }
}