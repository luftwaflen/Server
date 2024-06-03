using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IAdminRepository : IRepository<Admin>
{
    Task<Admin> GetAdminByIdAsync(Guid id);
}