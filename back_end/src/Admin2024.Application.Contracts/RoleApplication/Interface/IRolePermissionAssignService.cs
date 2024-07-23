using Admin2024.Instructions;

namespace Admin2024.Application.Contracts.RoleApplication.Interface;
public interface IRolePermissionAssignService<T>
{
  // 给角色分配权限
  Task<ReturnResult<T>> AssignRolePermission(Guid roleId,Guid perId);
  // 移除角色权限
  Task<ReturnResult<T>> RemoveRolePermission(Guid roleId,Guid perId);
}