using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IFamilyRepository : IRepository<Family>
{
    Task<Family> GetFamilyByIdAsync(Guid id);
}