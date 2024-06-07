using Domain.Models;

namespace API.Responses;

public class UserResponse
{
    public UserResponse(Guid id, string login, UserRoles role, Guid familyId, FamilyRole familyRole)
    {
        Id = id;
        Login = login;
        Role = role;
        FamilyId = familyId;
        FamilyRole = familyRole;
    }
    public UserResponse(Guid id, string login, UserRoles role)
    {
        Id = id;
        Login = login;
        Role = role;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public UserRoles Role { get; set; }
    public virtual Guid? FamilyId { get; set; }
    public virtual FamilyRole? FamilyRole { get; set; }
}