using Admin2024.Instructions;

namespace Admin2024.Application.Contracts.RoleApplication.Interface;
public interface IRolePermissionAssignAppService
{
  // 给角色分配权限
  Task<ReturnResult<string>> AssignRolePermission(Guid roleId,Guid perId);
  // 移除角色权限
  Task<ReturnResult<string>> RemoveRolePermission(Guid roleId,Guid perId);
}