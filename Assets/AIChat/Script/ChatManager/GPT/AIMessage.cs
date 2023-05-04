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
    public enum Role
    {
        system,
        user,
        assistant
    }

    [Serializable]
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