using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
{
    public FamilyRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Family> GetFamilyByIdAsync(Guid id)
    {
        var family = await _db.Families.FirstOrDefaultAsync(u => u.Id == id);

        return family;
    }
}