using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

namespace ThangChiba.GameCore
{
    public class BarkController : MonoBehaviour
    {
        [SerializeField] GameObject canvasContainer;
        [SerializeField] GameObject chatBubble;
        [SerializeField] float showTime = 5f;
        [SerializeField] bool barkOnIdle = false;
        [SerializeField][Range(10f, 30f)] float barkWaitTime;
        GameObject chat = null;
        TextMeshProUGUI textContent = null;
        Random rd;
        private void Start()
        {
            rd = new Random();
            StartCoroutine(BarkOnIdle());
        }

        IEnumerator BarkOnIdle()
        {
            while (barkOnIdle)
            {
                Bark(defaultBarks[rd.Next(0, defaultBarks.Count)],"ja");
                yield return new WaitForSeconds(barkWaitTime);
            }
        }

        public void Bark(string content, string language = "en")
        {
            if (String.IsNullOrWhiteSpace(content)) return;
            if (chat != null) Destroy(chat);
            chat = Instantiate(chatBubble, canvasContainer.transform);
            textContent = chat.GetComponentInChildren<TextMeshProUGUI>();
            textContent.text = content;
            CalcShowTime(content);
        }

        private void CalcShowTime(string content)
        {
            showTime += content.Length * (1 / 60f);
            if (showTime > 15f) showTime = 15f;
            Destroy(chat, showTime);
        }

        public void StopBark(float? second)
        {
            if (barkOnIdle == false) return;
            barkOnIdle = false;
            if (second != null)
            {
                Invoke("StartBark", (float)second);
            }
            void StartBark()
            {
                barkOnIdle = true;
            }
        }

        List<string> defaultBarks = new List<string>(){
        "Nice to meet you","How are you","Are you oke?"};
    }
}