using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository, IUserRepository userRepository)
    {
        _adminRepository = adminRepository;
        _userRepository = userRepository;
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
}