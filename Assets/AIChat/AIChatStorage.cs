
using System.Collections.Generic;
using UnityEngine;


namespace MMORPG.UI.AIChat
{
    [CreateAssetMenu(fileName = "Storage", menuName = "AIChat", order=0)]
    public class AIChatStorage : ScriptableObject
    {
        public List<AIMessage> messages;
    }
}