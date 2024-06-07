using Domain.Models;

namespace API.Responses;

public class AdminResponse
{
    public AdminResponse(Guid id, UserResponse user)
    {
        User = user;
    }
    public Guid Id { get; set; }
    public virtual UserResponse User { get; set; }
}