using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IPermissionDomainService
{
  // 创建权限
  Task<ReturnResult<Permission>> AddPermission(Permission permission);

  // 删除权限
  Task<ReturnResult<Permission>> RemovePermission(Guid id);
}