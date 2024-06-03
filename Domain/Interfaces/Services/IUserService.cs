using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IUserService : IService<User>
{
    Task<User> LoginAsync(string login, string password);
    Task<User> GetUserById(Guid id);
    Task<List<User>> CreateFamily(string name, User user, FamilyRole role);
}