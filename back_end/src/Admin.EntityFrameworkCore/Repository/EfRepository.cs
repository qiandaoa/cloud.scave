using Admin.Domain.Entity;
using Admin.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Admin.EntityFrameworkCore.Repository;
// 通用仓储接口的实现类
public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AdminDbContext _adminDb;
    private readonly DbSet<T> _table;
    public IQueryable<T> Table{get;}
    public EfRepository(AdminDbContext adminDb)
    {
      _adminDb = adminDb;
      // 新增等有修改状态的使用这个
      _table = _adminDb.Set<T>();
      // 纯查询使用这个
      Table = _table.AsNoTracking();
    }
    public async Task<T> CreateAsync(T entity)
{
    try
    {
        // 设置实体的默认属性
        entity.IsActived = true;
        entity.IsDeleted = false;

        // 将实体添加到数据库集合中
        await _table.AddAsync(entity);

        // 保存更改到数据库
        await _adminDb.SaveChangesAsync();

        // 返回创建成功的实体
        return entity;
    }
    catch (Exception ex)
    {
        // 可以在这里记录异常或者抛出自定义异常
        throw new Exception("创建实体时出现错误", ex);
    }
}


    public Task<T?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var list = await _table.AsNoTracking().ToListAsync();
        return list;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        // 最后更新时间
        entity.UpdatedAt = DateTime.Now;
        var res = _table.Update(entity);
        await _adminDb.SaveChangesAsync();
        return res.Entity;
    }
}