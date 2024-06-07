using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IChatRepository : IRepository<Chat>
{
    Task<Chat> GetChatByIdAsync(Guid id);
}