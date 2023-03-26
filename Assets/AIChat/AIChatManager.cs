using System.Collections.Generic;

namespace MMORPG.UI.AIChat
{
    public class AIChatManager
    {
        private List<AIChatHandler> listAIChatHandler;

        public void SendRequest()
        {
            //When receive callback run all cb handler
            listAIChatHandler.ForEach(x =>
            {
                x.OnReceiveResponse("hehe");
            });
        }
    }
}