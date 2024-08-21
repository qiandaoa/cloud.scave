using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Services;
public class RolePermissionAssignDomainService : IRolePermissionAssignDomainService
{
    private readonly IRepository<Role> _roleRep;
    private readonly IRepository<RolePermission> _rolePerRep;
    private readonly IRepository<Permission> _perRep;
    public RolePermissionAssignDomainService(IRepository<Role> roleRep, 
        IRepository<RolePermission> rolePerRep, 
        IRepository<Permission> perRep)
    {
        _roleRep = roleRep;
        _rolePerRep = rolePerRep;
        _perRep = perRep;
    }
    // 给角色分配权限
    public async Task<ReturnResult<string>> AssignRolePermission(Guid roleId, Guid permissionId)
    {
        var roleIsExist = await _roleRep.GetByIdAsync(roleId);
        var perIsExist = await _perRep.GetByIdAsync(permissionId);
        // 查找角色和权限是否都存在
        if(roleIsExist != null && perIsExist != null){
          var rolePermission = new RolePermission(roleId,permissionId);
          await _rolePerRep.AddAsync(rolePermission);
          return ReturnResult<string>.Success("给角色分配权限成功");
        }
        return ReturnResult<string>.Error("角色或权限不存在");
    }
    // 移除角色权限
    public async Task<ReturnResult<string>> RemoveRolePermission(Guid roleId, Guid permissionId)
    {
        var rolePerIsExist = _rolePerRep.Table.FirstOrDefault(x => x.RoleId == roleId && x.PermissionId == permissionId);
        if(rolePerIsExist != null){
          await _rolePerRep.DeleteAsync(rolePerIsExist.Id);
          return ReturnResult<string>.Success("移除角色权限成功");
        }
        return ReturnResult<string>.Error("移除角色失败");
    }
}