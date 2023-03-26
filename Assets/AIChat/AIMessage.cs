using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MMORPG.UI.AIChat
{
    public enum Role
    {
        system,
        user,
        assistant
    }

    [System.Serializable]
    public class AIMessage
    {
        public Role role;
        public string content;

        public AIMessage(Role role, string content)
        {
            this.role = role;
            this.content = content;
        }
    }
}