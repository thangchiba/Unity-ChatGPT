using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public abstract class ChatModeState : MonoBehaviour
    {
        public abstract void Setup();

        public virtual void Uninstall()
        {
            ChatManager.Instance.ChatGPT.ResetHandler();
        }
    }
}