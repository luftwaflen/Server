using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipeRelationRepository : IRepository<RecipeRelation>
{
    Task<RecipeRelation> GetRecipeRelationByIdAsync(Guid patientId, Guid doctorId, Guid recipeId);
}