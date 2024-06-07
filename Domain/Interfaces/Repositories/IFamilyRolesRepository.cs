using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IFamilyRolesRepository : IRepository<FamilyRole>
{
    Task<FamilyRole> GetFamilyRoleByIdAsync(Guid id);
    Task<FamilyRole> GetFamilyRoleByNameAsync(string name);
}