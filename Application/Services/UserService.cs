using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFamilyRepository _familyRepository;

    public UserService(IUserRepository userRepository, IFamilyRepository familyRepository)
    {
        _userRepository = userRepository;
        _familyRepository = familyRepository;
    }

    public async Task<User> LoginAsync(string login, string password)
    {
        var user = await _userRepository.GetUserByLoginAsync(login);
        if (user.Password == password) return user;
        return null;
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user;
    }

    public async Task<List<User>> CreateFamily(string name, User user, FamilyRole role)
    {
        var family = new Family(name, user, role);
        await _familyRepository.AddAsync(family);
        user.Family = family;
        user.FamilyRole = role;
        await _userRepository.UpdateAsync(user);
        return family.FamilyMembers;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users;
    }

    public async Task AddAsync(User model)
    {
        await _userRepository.AddAsync(model);
    }

    public async Task UpdateAsync(User model)
    {
        await _userRepository.UpdateAsync(model);
    }

    public async Task DeleteAsync(User model)
    {
        await _userRepository.DeleteAsync(model);
    }
}