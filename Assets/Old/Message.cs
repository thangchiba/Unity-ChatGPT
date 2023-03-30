using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
