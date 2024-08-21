using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Interface;
public interface IPermissionDomainService
{
  // 获取所有权限
  Task<ReturnResult<List<Permission>>> GetAllPermission();
  // 创建权限
  Task<ReturnResult<Permission>> AddPermission(Permission permission);

  // 删除权限
  Task<ReturnResult<Permission>> RemovePermission(Guid id);

  // 修改权限
  Task<ReturnResult<Permission>> UpdatePermission(Guid id, Permission permission);
  // 根据权限名称查找
  Permission? GetPermissionByName(string permissionName);
}