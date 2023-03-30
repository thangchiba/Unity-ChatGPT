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
        public string role;
        public string content;

        public AIMessage(Role role, string content)
        {
            this.role = role.ToString();
            this.content = content;
        }
    }
}