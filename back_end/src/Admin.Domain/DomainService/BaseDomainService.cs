using Admin.Domain.Entity;
using Admin.Domain.Interface;
using Admin.Domain.ObjectValue;

namespace Admin.Domain.DomainService;
public class BaseDomainService<T> : IBaseDomainService<T> where T : BaseEntity
{
    private readonly IRepository<T> _entityRepository;
    public BaseDomainService(IRepository<T> entityRepository)
    {
      _entityRepository = entityRepository;
    }
    public async Task<DomainResult<T>> DeleteAsync(Guid id)
    {
        // 根据id查询信息是否存在 
        var entity = await  _entityRepository.GetByIdAsync(id);
        // 如果不存在
        if(entity == null){
          return DomainResult<T>.Error("查无此人，请重新确认");
        }
        // 如果存在，但是已经被删除过了
        if(entity.IsDeleted == true){
          return DomainResult<T>.Error("别删了，早被删除了");
        }
        // 如果存在且没有被删除
        entity.IsDeleted = true;
        var res = await _entityRepository.UpdateAsync(entity);
        return DomainResult<T>.Success(res);
    }

    public Task<DomainResult<T>> DisableAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DomainResult<T>> EnableAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DomainResult<T>> SetDisplayOrderAsync(Guid id, int orderNumber)
    {
        throw new NotImplementedException();
    }

    public Task<DomainResult<T>> SetRemarkAsync(Guid id, string remarks)
    {
        throw new NotImplementedException();
    }
}