using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IFamilyRolesRepository _familyRolesRepository;

    public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IFamilyRolesRepository familyRolesRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
    {
        _adminRepository = adminRepository;
        _userRepository = userRepository;
        _familyRolesRepository = familyRolesRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        var admins = await _adminRepository.GetAllAsync();
        return admins;
    }

    public async Task AddAsync(Admin model)
    {
        await _adminRepository.AddAsync(model);
    }

    public async Task UpdateAsync(Admin model)
    {
        await _adminRepository.UpdateAsync(model);
    }

    public async Task DeleteAsync(Admin model)
    {
        await _adminRepository.DeleteAsync(model);
    }

    public async Task<Admin> RegisterAdminAsync(string login, string password)
    {
        var admin = new Admin(login, password);
        await _adminRepository.AddAsync(admin);
        return admin;
    }

    public async Task<Admin> GetAdminByIdAsync(Guid id)
    {
        var admin = await _adminRepository.GetAdminByIdAsync(id);
        return admin;
    }

    public async Task CreateFamilyRole(string name)
    {
        var role = new FamilyRole();
        role.Name = name;
        await _familyRolesRepository.AddAsync(role);
    }

    public async Task AddPersonalDoctor(Guid doctorId, Guid patientId)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
        var patient = await _patientRepository.GetPatientByIdAsync(patientId);
        patient.PersonalDoctor = doctor;
        doctor.Patients.Add(patient);
        await _patientRepository.UpdateAsync(patient);
        await _doctorRepository.UpdateAsync(doctor);
    }
}