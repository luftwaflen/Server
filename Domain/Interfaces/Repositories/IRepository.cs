namespace Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(T model);
}