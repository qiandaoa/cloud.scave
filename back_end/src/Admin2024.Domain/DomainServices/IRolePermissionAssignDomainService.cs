using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IRolePermissionAssignDomainService
{
    // 给角色分配权限
    public Task<ReturnResult<Role>> AssignRolePermission(Guid roleId, Guid permissionId);
    // 移除角色权限
    public Task<ReturnResult<Role>> RemovePermission(Guid roleId, Guid permissionId);
}