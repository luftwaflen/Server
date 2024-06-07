namespace Domain.Models;

public class Message
{
    public Message()
    {
        Id = Guid.NewGuid();
    }

    public Message(string text) : this()
    {
        Text = text;
    }

    public Message(User user, string text) : this()
    {
        Text = text;
        Sender = user;
    }

    public Guid Id { get; set; }
    public virtual User Sender { get; set; }
    public string Text { get; set; }
}