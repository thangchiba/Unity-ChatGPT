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

namespace ThangChibaGPT

{
    public class NpcChatController : AIChatController
    {
        private BarkController barkController;

        private void Awake()
        {
            barkController = GetComponentInChildren<BarkController>();
        }

        public override void OnReceiveChunkResponse(string content)
        {
            barkController.SetBark(content);
        }
    }
}