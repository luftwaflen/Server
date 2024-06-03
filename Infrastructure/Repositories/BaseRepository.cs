using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DiaryDbContext _db;
    protected BaseRepository(DiaryDbContext context)
    {
        _db = context;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var models = await _db.Set<T>().ToListAsync();
        return models;
    }

    public async Task AddAsync(T model)
    {
        await _db.Set<T>().AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T model)
    {
        _db.Set<T>().Update(model);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T model)
    {
        _db.Set<T>().Remove(model);
        await _db.SaveChangesAsync();
    }
}