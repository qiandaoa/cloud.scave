using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Instructions;
using Admin2024.Domain.System;

namespace Admin2024.Application.Contracts.RoleApplication.Interface;
public interface IRoleAppService
{
  // 获取指定id角色
  Task<ReturnResult<Role>> GetRoleById(Guid id);
  // 获取全部角色（分页查询）
  Task<ReturnResult<List<Role>>> GetAllRole();
  // 添加角色
  Task<ReturnResult<Role>> AddRole(RoleCreateInfoDto input);
  // 修改角色
  Task<ReturnResult<Role>> UpdateRole(Guid roleId,RoleUpdateInfoDto input);
  // 删除角色
  Task<ReturnResult<Role>> DeleteRole(Guid roleId);

}