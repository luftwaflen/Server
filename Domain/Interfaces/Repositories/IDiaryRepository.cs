using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IDiaryRepository : IRepository<Diary>
{
    Task<Diary> GetDiaryByIdAsync(Guid id);
}