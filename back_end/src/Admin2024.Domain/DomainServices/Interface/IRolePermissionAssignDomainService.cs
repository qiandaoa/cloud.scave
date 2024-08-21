using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Interface;
public interface IRolePermissionAssignDomainService
{
    // 给角色分配权限
    public Task<ReturnResult<string>> AssignRolePermission(Guid roleId, Guid permissionId);
    // 移除角色权限
    public Task<ReturnResult<string>> RemoveRolePermission(Guid roleId, Guid permissionId);
}