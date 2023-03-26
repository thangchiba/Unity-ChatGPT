using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatPlayer : MonoBehaviour,IChatHandler
    {
        //TODO Add Bark class
        private void OnCollisionEnter(Collision collision)
        {
            //On Collision then add AIChatHandler to NPC
            throw new NotImplementedException();
        }

        public void OnChatSubmit()
        {
            //Handle event when chat submitted
            throw new System.NotImplementedException();
        }
    }
}