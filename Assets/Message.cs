using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] public Image avatar;
    [SerializeField] public TextMeshProUGUI content;

    public void SetContent(string content)
    {
        this.content.text = content;
    }
    public void SetAvatar(string role)
    {
        // if(role == "user") avatar
    }
}
