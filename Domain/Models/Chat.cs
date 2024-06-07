namespace Domain.Models;

public class Chat
{
    public Chat()
    {
        Id = Guid.NewGuid();
        Members = new List<User>();
        Messages = new List<Message>();
    }

    public Chat(string name) : this()
    {
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<User> Members { get; set; }
    public virtual List<Message> Messages { get; set; }
}