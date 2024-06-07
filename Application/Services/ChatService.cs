using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class ChatService : IChatService
{
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(IUserRepository userRepository, IChatRepository chatRepository, IMessageRepository messageRepository)
    {
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _messageRepository = messageRepository;
    }

    public async Task<IEnumerable<Chat>> GetAllAsync()
    {
        var chats = await _chatRepository.GetAllAsync();
        return chats;
    }

    public async Task AddAsync(Chat model)
    {
        await _chatRepository.AddAsync(model);
    }

    public async Task UpdateAsync(Chat model)
    {
        await _chatRepository.UpdateAsync(model);
    }

    public async Task DeleteAsync(Chat model)
    {
        await _chatRepository.DeleteAsync(model);
    }

    public async Task AddUser(Guid chatId, Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        var chat = await _chatRepository.GetChatByIdAsync(chatId);
        user.Chats.Add(chat);
        chat.Members.Add(user);
        await _chatRepository.UpdateAsync(chat);
        await _userRepository.UpdateAsync(user);
    }

    public async Task<List<Chat>> GetUserChats(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        return user.Chats;
    }

    public async Task<Chat> GetChat(Guid chatId)
    {
        var chat = await _chatRepository.GetChatByIdAsync(chatId);
        return chat;
    }

    public async Task<List<Message>> GetChatMessages(Guid chatId)
    {
        var chat = await _chatRepository.GetChatByIdAsync(chatId);
        return chat.Messages;
    }

    public async Task<List<Message>> AddMessage(Guid userId, Guid chatId, string text)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        var chat = await _chatRepository.GetChatByIdAsync(chatId);
        var message = new Message(user, text);
        chat.Messages.Add(message);
        await _messageRepository.AddAsync(message);
        await _chatRepository.UpdateAsync(chat);
        return chat.Messages;
    }
}