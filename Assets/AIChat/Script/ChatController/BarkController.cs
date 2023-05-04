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

namespace ThangChibaGPT

{
    public class BarkController : MonoBehaviour
    {
        [SerializeField] private GameObject barkBox;
        [SerializeField] private TextMeshProUGUI barkContent;
        [Range(1f, 10f)] public float hideAfterSeconds = 5f;

        public void HideBark()
        {
            barkBox.SetActive(false);
        }

        public void SetBark(string content)
        {
            if (!barkBox.activeSelf)
                barkBox.SetActive(true);
            barkContent.text = content;
            CancelInvoke(nameof(HideBark));
            Invoke(nameof(HideBark), hideAfterSeconds);
        }
    }
}