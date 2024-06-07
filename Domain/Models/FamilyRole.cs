namespace Domain.Models;

public class FamilyRole
{
    public FamilyRole()
    {
        Id = Guid.NewGuid();
    }

    public FamilyRole(string name) : this()
    {
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}