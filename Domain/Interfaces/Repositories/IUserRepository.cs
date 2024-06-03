using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByLoginAsync(string login);
    Task<User> GetUserByIdAsync(Guid id);
}