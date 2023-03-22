using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ChatBox : MonoBehaviour
{
    [SerializeField] private GPTAPI api;
    [SerializeField] private Frame frame;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI chatContent;
    [SerializeField] private Boolean isChatAI;

    private void OnEnable()
    {
        inputField.ActivateInputField();
    }

    public void SubmitChat()
    {
        frame.AddChatMessage(chatContent.text,"user");
        chatContent.text = "";
        inputField.ActivateInputField();
        ChatAI();
    }

    public delegate void ChatCallback(string response);
    private void ChatAI()
    {
        var message = frame.AddChatMessage("","assistant");
        api.Send(chatContent.text,message.SetContent);
    }
}
