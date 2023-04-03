using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace MMORPG.UI.AIChat
{
    public class BarkController : MonoBehaviour
    {
        [SerializeField] GameObject chatBubble;
        [SerializeField] private TextMeshProUGUI barkContent;

        private void OnEnable()
        {
            SetBark("This is bark");
        }
        
        public void HideBark()
        {
            // var showTime = minShowTime + content.Length * (1 / 60f);
            //     if (showTime > maxShowTime) showTime = 15f;
            chatBubble.SetActive(false);
        }

        public void SetBark(string content)
        {
            if(!chatBubble.activeSelf)
                chatBubble.SetActive(true);
            barkContent.text = content;
        }
    }
}