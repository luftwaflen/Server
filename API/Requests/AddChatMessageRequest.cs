namespace API.Requests;

public class AddChatMessageRequest
{
    public string ChatId { get; set; }
    public string SenderId { get; set; }
    public string Text { get; set; }
}