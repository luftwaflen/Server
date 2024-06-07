using Domain.Models;

namespace API.Responses;

public class PatientResponse
{
    public PatientResponse(Guid id, UserResponse user)
    {
        Id = id;
        User = user;
    }
    public Guid Id { get; set; }
    public virtual UserResponse User { get; set; }
    //public virtual List<RecipeRelation> RecipeRelations { get; set; }
}