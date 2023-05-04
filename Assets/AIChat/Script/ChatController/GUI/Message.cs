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

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ThangChibaGPT
{
    public class Message : MonoBehaviour
    {
        [SerializeField] public Sprite avatarUser;
        [SerializeField] public Sprite avatarAssistant;
        [SerializeField] public Image showAvatar;
        [SerializeField] public TextMeshProUGUI content;

        public void SetContent(string content)
        {
            this.content.text = content;
        }

        public void SetAvatar(string role)
        {
            showAvatar.sprite = role == "user" ? avatarUser : avatarAssistant;
        }
    }
}