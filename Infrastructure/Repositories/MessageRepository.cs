using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(DiaryDbContext context) : base(context)
    {
    }
}