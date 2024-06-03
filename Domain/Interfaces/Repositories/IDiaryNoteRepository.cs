using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IDiaryNoteRepository : IRepository<DiaryNote>
{
    Task<DiaryNote> GetDiaryNoteByIdAsync(Guid id);
}