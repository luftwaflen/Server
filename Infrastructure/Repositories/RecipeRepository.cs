using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
{
    public RecipeRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Recipe> GetRecipeByIdAsync(Guid id)
    {
        var recipe = await _db.Recipes.FirstOrDefaultAsync(u => u.Id == id);

        return recipe;
    }

    public async Task<List<Recipe>> GetPatientRecipesAsync(Guid patientId)
    {
        var recipes = await _db.RecipeRelations
            .Where(rr => rr.PatientId == patientId)
            .Select(rr => rr.Recipe)
            .ToListAsync();

        return recipes;
    }

    public async Task<List<Recipe>> GetDoctorRecipesAsync(Guid doctorId)
    {
        var recipes = await _db.RecipeRelations
            .Where(rr => rr.DoctorId == doctorId)
            .Select(rr => rr.Recipe)
            .ToListAsync();

        return recipes;
    }
}