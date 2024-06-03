using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeRelationRepository _recipeRelationRepository;

    public DoctorService(IDoctorRepository doctorRepository,
        IRecipeRepository recipeRepository,
        IRecipeRelationRepository recipeRelationRepository,
        IPatientRepository patientRepository)
    {
        _doctorRepository = doctorRepository;
        _recipeRepository = recipeRepository;
        _recipeRelationRepository = recipeRelationRepository;
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();
        return doctors;
    }

    public async Task AddAsync(Doctor model)
    {
        await _doctorRepository.AddAsync(model);
    }

    public async Task UpdateAsync(Doctor model)
    {
        await _doctorRepository.UpdateAsync(model);
    }

    public async Task DeleteAsync(Doctor model)
    {
        await _doctorRepository.DeleteAsync(model);
    }

    public async Task<Doctor> RegisterDoctorAsync(string login, string password, string firstName, string secondName)
    {
        var doctor = new Doctor(login, password, firstName, secondName);
        _doctorRepository.AddAsync(doctor);
        return doctor;
    }

    public async Task<Doctor> GetDoctorByIdAsync(Guid id)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
        return doctor;
    }

    public async Task<List<Patient>> GetDoctorPatients(Guid doctorId)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
        return doctor.Patients;
    }

    public async Task<List<Recipe>> GetDoctorRecipes(Guid doctorId)
    {
        var recipes = await _recipeRepository.GetDoctorRecipesAsync(doctorId);
        return recipes;
    }

    public async Task AddRecipeAsync(Guid patientId, Guid doctorId, string text)
    {
        var recipe = new Recipe(text);
        await _recipeRepository.AddAsync(recipe);
        var patient = await _patientRepository.GetPatientByIdAsync(patientId);
        var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
        var recipeRelation = new RecipeRelation(patientId, doctorId, recipe.Id, patient, doctor, recipe);
        recipe.RecipeRelation = recipeRelation;
        await _recipeRelationRepository.AddAsync(recipeRelation);
    }
}