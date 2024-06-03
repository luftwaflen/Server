namespace Domain.Models;

public class Family
{
    public Family()
    {
        Id = Guid.NewGuid();
        FamilyMembers = new List<User>();
    }

    public Family(string name, User user, FamilyRole familyRole) : this()
    {
        FamilyMembers.Add(user);
        user.FamilyRole = familyRole;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<User> FamilyMembers { get; set; }
}