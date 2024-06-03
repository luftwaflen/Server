using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DiaryNoteRepository : BaseRepository<DiaryNote>, IDiaryNoteRepository
{
    public DiaryNoteRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<DiaryNote> GetDiaryNoteByIdAsync(Guid id)
    {
        var diaryNote = await _db.DiaryNotes.FirstOrDefaultAsync(u => u.Id == id);

        return diaryNote;
    }
}