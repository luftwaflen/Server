using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPatientService : IService<Patient>
{
    Task<Patient> RegisterPatient(string login, string password);
    Task<Patient> GetPatientByIdAsync(Guid id);
    Task<List<DiaryNote>> AddPatientDiaryNote(Guid patientId, DiaryNote diaryNote);
    Task<List<Recipe>> GetPatientRecipes(Guid patientId);
    Task<List<DiaryNote>> GetPatientDiaryNotes(Guid patientId);
}