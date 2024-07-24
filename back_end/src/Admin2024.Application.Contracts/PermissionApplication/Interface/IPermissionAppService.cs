using Admin2024.Application.Contracts.PermissionApplication.Dto;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Application.Contracts.PermissionApplication.Interface;
public interface IPermissionAppService
{
  // 创建权限
  Task<ReturnResult<Permission>> AddPermission(PermissionCreateInfoDto input);

  // 删除权限
  Task<ReturnResult<Permission>> DeletePermission(Guid id);

  // 创建资源权限
}