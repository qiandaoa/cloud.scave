using Admin.Domain.Entity;
using Admin.Domain.ObjectValue;

namespace Admin.Domain.DomainService;
public interface IBaseDomainService<T> where T:BaseEntity
{
  // 删除
  Task<DomainResult<T>> DeleteAsync(Guid id);
  // 启用
  Task<DomainResult<T>> EnableAsync(Guid id);
  // 禁用
  Task<DomainResult<T>> DisableAsync(Guid id);
  // 设置显示顺序
  Task<DomainResult<T>> SetDisplayOrderAsync(Guid id,int orderNumber);
  // 设置备注
  Task<DomainResult<T>> SetRemarkAsync(Guid id,string remarks);
}