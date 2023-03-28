using System.Collections.Generic;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class AIChatManager : MonoBehaviour
    {
        private List<AIChatHandler> listAIChatHandler;

        public void AttachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Add((handler));
        }
        
        public void DetachHandler(AIChatHandler handler)
        {
            listAIChatHandler.Remove((handler));
        }
        
        public void SendRequest(AIChatStorage messages)
        {
            //When receive callback run all cb handler
            listAIChatHandler.ForEach(x =>
            {
                x.OnReceiveResponse("hehe");
            });
        }
    }
}