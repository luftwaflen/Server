using Domain.Models;

namespace API.Responses;

public class DoctorResponse
{
    public DoctorResponse(Guid id, UserResponse user, string firstName, string secondName)
    {
        Id = id;
        User = user;
        FirstName = firstName;
        SecondName = secondName;
    }
    public Guid Id { get; set; }
    public virtual UserResponse User { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
}