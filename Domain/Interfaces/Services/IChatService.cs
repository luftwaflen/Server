using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IChatService : IService<Chat>
{
    Task AddUser(Guid chatId, Guid userId);
    Task<List<Chat>> GetUserChats(Guid userId);
    Task<Chat> GetChat(Guid chatId);
    Task<List<Message>> GetChatMessages(Guid chatId);
    Task<List<Message>> AddMessage(Guid userId, Guid chatId, string text);
}