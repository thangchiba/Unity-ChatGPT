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
    public class Choice
    {
        public Delta delta;
        public int index;
        public string finish_reason;
    }
}