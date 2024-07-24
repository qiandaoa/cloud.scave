using Admin2024.Application.Contracts.PermissionApplication.Dto;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Application.Contracts.PermissionApplication.Interface;
public interface IPermissionAppService
{
  // 获取全部权限
  Task<ReturnResult<List<Permission>>> GetAllPermission();
  // 创建权限
  Task<ReturnResult<PerCreateInfoDto>> AddPermission(PerCreateInfoDto input);

  // 删除权限
  Task<ReturnResult<Permission>> DeletePermission(Guid id);

  // 修改权限
  Task<ReturnResult<Permission>> UpdatePermission(Guid id, PerUpdateInfoDto input);

//------------------------------------资源--------------------------------------- 

  // 获取全部资源权限
  Task<ReturnResult<List<Resource>>> GetAllResource();

  // 创建资源权限
  Task<ReturnResult<ResCreateInfoDto>> AddResource(ResCreateInfoDto input);

  // 删除资源权限
  Task<ReturnResult<Resource>> DeleteResource(Guid id);

  // 修改资源权限
  Task<ReturnResult<Resource>> UpdateResource(Guid id, ResUpdateInfoDto input);

//------------------------------------操作--------------------------------------- 

  // 获取全部操作权限
  Task<ReturnResult<List<Operation>>> GetAllOperation();
  // 创建操作权限
  Task<ReturnResult<OperCreateInfoDto>> AddOperation(OperCreateInfoDto input);

  // 删除操作权限
  Task<ReturnResult<Operation>> DeleteOperation(Guid id);
  // 修改操作权限
  Task<ReturnResult<Operation>> UpdateOperation(Guid id, OperUpdateInfoDto input);
}