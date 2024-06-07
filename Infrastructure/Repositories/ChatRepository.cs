using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatRepository : BaseRepository<Chat>, IChatRepository
{
    public ChatRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Chat> GetChatByIdAsync(Guid id)
    {
        var chat = await _db.Set<Chat>().FirstOrDefaultAsync(u => u.Id == id);

        return chat;
    }
}