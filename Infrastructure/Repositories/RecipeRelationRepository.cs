using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RecipeRelationRepository : BaseRepository<RecipeRelation>, IRecipeRelationRepository
{
    public RecipeRelationRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<RecipeRelation> GetRecipeRelationByIdAsync(Guid patientId, Guid doctorId, Guid recipeId)
    {
        var recipeRelation = await _db.RecipeRelations
            .FirstOrDefaultAsync(u => u.PatientId == patientId && 
                                      u.DoctorId == doctorId &&
                                      u.RecipeId == recipeId);

        return recipeRelation;
    }
}