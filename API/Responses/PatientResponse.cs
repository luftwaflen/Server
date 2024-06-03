using Domain.Models;

namespace API.Responses;

public class PatientResponse
{
    public Guid Id { get; set; }
    public virtual User User { get; set; }
    public virtual Doctor? PersonalDoctor { get; set; }
    public virtual List<RecipeRelation> RecipeRelations { get; set; }
}