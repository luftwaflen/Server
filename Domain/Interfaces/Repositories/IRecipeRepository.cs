using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe> GetRecipeByIdAsync(Guid id);
    Task<List<Recipe>> GetPatientRecipesAsync(Guid patientId);
    Task<List<Recipe>> GetDoctorRecipesAsync(Guid doctorId);
}