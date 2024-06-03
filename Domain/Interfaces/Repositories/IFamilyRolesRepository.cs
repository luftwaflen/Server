using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IFamilyRolesRepository
{
    Task<FamilyRole> GetFamilyRoleByIdAsync(Guid id);
}