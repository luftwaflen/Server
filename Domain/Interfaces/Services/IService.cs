namespace Domain.Interfaces.Services;

public interface IService<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(T model);
}