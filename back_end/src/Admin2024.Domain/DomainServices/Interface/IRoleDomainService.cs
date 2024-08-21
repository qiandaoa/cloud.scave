using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Interface;
public interface IRoleDomainService
{
  // 获取指定id角色
  Task<ReturnResult<Role>> GetRoleById(Guid id);
  // 获取全部角色
  Task<ReturnResult<List<Role>>> GetAllRole();
   // 添加角色
  Task<ReturnResult<Role>> AddRole(Role role);
  // 修改角色
  Task<ReturnResult<Role>> UpdateRole(Guid roleId, Role role);
  // 删除角色
  Task<ReturnResult<Role>> DeleteRole(Guid roleId);
  // 获取角色名（用于判断是否重名)
  Role? GetByRoleName(string roleName);

}