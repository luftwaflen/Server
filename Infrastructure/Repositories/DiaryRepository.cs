using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DiaryRepository : BaseRepository<Diary>, IDiaryRepository
{
    public DiaryRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Diary> GetDiaryByIdAsync(Guid id)
    {
        var diary = await _db.Diaries.FirstOrDefaultAsync(u => u.Id == id);

        return diary;
    }
}