using Admin2024.Domain;
using Admin2024.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Admin2024.EntityFramework;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    public IQueryable<T> Table { get; }
    private readonly AdminDbContext _db;
    private readonly DbSet<T> _tb;
    public Repository(AdminDbContext db)
    {
        _db = db;
        _tb = _db.Set<T>();
        Table = _tb.AsNoTracking();
    }
    public async Task<T> AddAsync(T entity)
    {
        await _tb.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public Task<T?> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

        entity.IsDeleted = true;
        _tb.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public Task<List<T>> GetAsync()
    {
        return _tb.ToListAsync();
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        return _tb.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        _tb.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public Task<T?> UpdateActiveState(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> UpdateActiveState(T entity)
    {
        throw new NotImplementedException();
    }
}