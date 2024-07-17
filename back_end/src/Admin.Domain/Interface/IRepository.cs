using Admin.Domain.Entity;

namespace Admin.Domain.Interface;
public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> Table{ get; }
    // 根据Id获取实体
    Task<T?> GetByIdAsync(Guid id);
    // 获取实体列表
    Task<List<T>> GetAllAsync();
    // 创建实体
    Task<T> CreateAsync(T entity);
    // 修改实体
    Task<T> UpdateAsync(T entity);
    // 删除实体
    Task<T?> DeleteAsync(Guid id);

}