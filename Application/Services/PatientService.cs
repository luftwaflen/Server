using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Reflection;

namespace Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDiaryRepository _diaryRepository;
    private readonly IDiaryNoteRepository _diaryNoteRepository;
    private readonly IRecipeRepository _recipeRepository;

    public PatientService(
        IPatientRepository patientRepository,
        IDiaryRepository diaryRepository,
        IDiaryNoteRepository diaryNoteRepository,
        IRecipeRepository recipeRepository)
    {
        _patientRepository = patientRepository;
        _diaryRepository = diaryRepository;
        _diaryNoteRepository = diaryNoteRepository;
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();
        return patients;
    }

    public async Task AddAsync(Patient model)
    {
        await _patientRepository.AddAsync(model);
    }

    public async Task UpdateAsync(Patient model)
    {
        await _patientRepository.UpdateAsync(model);
    }

    public async Task DeleteAsync(Patient model)
    {
        await _patientRepository.DeleteAsync(model);
    }

    public async Task<Patient> RegisterPatient(string login, string password)
    {
        var patient = new Patient(login, password);
        await _patientRepository.AddAsync(patient);
        //await _diaryRepository.AddAsync(patient.Diary);
        return patient;
    }

    public async Task<Patient> GetPatientByIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(id);
        return patient;
    }

    public async Task<List<DiaryNote>> AddPatientDiaryNote(Guid patientId, DiaryNote diaryNote)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(patientId);
        patient.Diary.DiaryNotes.Add(diaryNote);
        await _diaryNoteRepository.AddAsync(diaryNote);
        await _patientRepository.UpdateAsync(patient);
        return patient.Diary.DiaryNotes;
    }

    public async Task<List<Recipe>> GetPatientRecipes(Guid patientId)
    {
        var recipes = await _recipeRepository.GetPatientRecipesAsync(patientId);
        return recipes;

    }

    public async Task<List<DiaryNote>> GetPatientDiaryNotes(Guid patientId)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(patientId);
        return patient.Diary.DiaryNotes;
    }
}