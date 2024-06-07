using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IUserService : IService<User>
{
    Task<User> LoginAsync(string login, string password);
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByLogin(string login);
    Task<List<User>> CreateFamily(string name, User user);
    Task<List<User>> GetFamily(Guid userId);
    Task<List<User>> InviteToFamily(Guid familyId, Guid userId);
}