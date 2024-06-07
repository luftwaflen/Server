namespace Domain.Models;

public class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    public User(string login, string password) : this()
    {
        Login = login;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRoles Role { get; set; }
    public virtual List<Chat>? Chats { get; set; }
    public virtual Family? Family { get; set; }
    public virtual FamilyRole? FamilyRole { get; set; }
}