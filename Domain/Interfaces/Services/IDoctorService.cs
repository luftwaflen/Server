using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IDoctorService : IService<Doctor>
{
    Task<Doctor> RegisterDoctorAsync(string login, string password, string firstName, string secondName);
    Task<Doctor> GetDoctorByIdAsync(Guid id);
    Task<List<Patient>> GetDoctorPatients(Guid doctorId);
    Task<List<Recipe>> GetDoctorRecipes(Guid doctorId);
    Task AddRecipeAsync(Guid patientId, Guid doctorId, string text);
}