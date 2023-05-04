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

using UnityEngine;

namespace ThangChibaGPT

{
    public abstract class ChatModeState : MonoBehaviour
    {
        public abstract void OnSetup();

        public abstract void OnUninstall();

        public abstract void SubmitChat(string content);
    }
}