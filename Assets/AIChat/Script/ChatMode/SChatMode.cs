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

using System;

namespace ThangChibaGPT

{
    [Serializable]
    public struct SChatMode
    {
        public EChatMode eChatMode;
        public ChatModeState chatState;
    }
}