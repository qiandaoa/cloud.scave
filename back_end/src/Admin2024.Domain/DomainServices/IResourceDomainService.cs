using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IResourceDomainService
{
  // 新建资源权限
  Task<ReturnResult<Resource>> AddResource(Resource resource);

  // 移除资源权限
  Task<ReturnResult<Resource>> RemoveResource(Guid id);
}