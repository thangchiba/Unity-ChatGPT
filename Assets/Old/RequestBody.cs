using System.Collections.Generic;

[System.Serializable]
public class RequestBody
{
    public string model = "gpt-3.5-turbo";
    public List<MessageModel> messages;
    public bool stream = true;
}

[System.Serializable]
public class MessageModel
{
    public string role;
    public string content;
}

public enum Role
{
    system,
    assistant,
    user
}