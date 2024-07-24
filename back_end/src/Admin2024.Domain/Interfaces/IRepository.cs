namespace Admin2024.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> Table{get;}
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAsync();
    Task<T?> DeleteAsync(T entity);
    Task<T?> DeleteAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<T?> UpdateActiveState(Guid id,bool or);
    Task<T?> UpdateActiveState(T entity);
}