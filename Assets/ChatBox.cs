using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ChatBox : MonoBehaviour
{
    [SerializeField] private Frame frame;
    [SerializeField] private TextMeshProUGUI chatContent;

    public void SubmitChat()
    {
        frame.AddChatMessage(chatContent.text,"user");
        chatContent.text = "";
    }
}
