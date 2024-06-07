using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IAdminService : IService<Admin>
{
    Task<Admin> RegisterAdminAsync(string login, string password);
    Task<Admin> GetAdminByIdAsync(Guid id);
    Task CreateFamilyRole(string role);
    Task AddPersonalDoctor(Guid doctorId, Guid patientId);
}