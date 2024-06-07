namespace API.Responses;

public class MessageResponse
{
    public MessageResponse(Guid id, string sender, string text)
    {
        Id = id;
        Sender = sender;
        Text = text;
    }
    public Guid Id { get; set; }
    public string Sender { get; set; }
    public string Text { get; set; }
}