using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AdminRepository : BaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Admin> GetAdminByIdAsync(Guid id)
    {
        //var admin = await _db.Set<Admin>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        var admin = await _db.Set<Admin>().FirstOrDefaultAsync(u => u.Id == id);

        return admin;
    }
}