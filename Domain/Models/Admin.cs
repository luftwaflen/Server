namespace Domain.Models;

public class Admin
{
    public Admin()
    {
        Id = Guid.NewGuid();
    }
    public Admin(string login, string password) : this()
    {
        User = new User(login, password);
        User.Role = UserRoles.Admin;
    }

    public Admin(User user) : this()
    {
        User = user;
        User.Role = UserRoles.Admin;
    }

    public Guid Id { get; set; }
    public virtual User User { get; set; }
}