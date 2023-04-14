using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MMORPG.UI.AIChat
{
    public class BarkController : MonoBehaviour
    {
        [SerializeField] GameObject barkBox;
        [SerializeField] private TextMeshProUGUI barkContent;
        [Range(1f,10f)] public float hideAfterSeconds = 5f;
        
        public void HideBark()
        {
            barkBox.SetActive(false);
        }

        public void SetBark(string content)
        {
            if(!barkBox.activeSelf)
                barkBox.SetActive(true);
            barkContent.text = content;
            CancelInvoke(nameof(HideBark));
            Invoke(nameof(HideBark),hideAfterSeconds);
        }
    }
}