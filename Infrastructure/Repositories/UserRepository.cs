using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        //var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<User> GetUserByLoginAsync(string login)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Login == login);

        return user;
    }
}