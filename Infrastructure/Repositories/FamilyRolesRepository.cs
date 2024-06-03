using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FamilyRolesRepository : BaseRepository<FamilyRole>, IFamilyRolesRepository
{
    public FamilyRolesRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<FamilyRole> GetFamilyRoleByIdAsync(Guid id)
    {
        var familyRole = await _db.FamilyRoles.FirstOrDefaultAsync(u => u.Id == id);

        return familyRole;
    }
}