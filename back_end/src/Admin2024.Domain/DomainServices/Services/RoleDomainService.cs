using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Admin2024.Domain.DomainServices.Services;
public class RoleDomainService : IRoleDomainService
{
    private readonly IRepository<Role> _roleRep;
    public RoleDomainService(IRepository<Role> roleRep)
    {
      _roleRep = roleRep;
    }
    // 添加角色
    public async Task<ReturnResult<Role>> AddRole(Role role)
    {
        var roleInfo = _roleRep.Table.FirstOrDefault(r => r.RoleName == role.RoleName);
        if(roleInfo != null){
          return ReturnResult<Role>.Error("角色已存在");
        }
        await _roleRep.AddAsync(role);
        return ReturnResult<Role>.Success(role);
    }

    // 删除角色
    public async Task<ReturnResult<Role>> DeleteRole(Guid roleId)
    {
        var role = await _roleRep.GetByIdAsync(roleId);
        if(role == null){
          return ReturnResult<Role>.Error("该角色不存在");
        }
        if(role.IsDeleted == true){
          return ReturnResult<Role>.Error("该角色已被删除");
        }
        await _roleRep.DeleteAsync(roleId);
        return ReturnResult<Role>.Success(role);
    }

    // 获取所有角色
    public async Task<ReturnResult<List<Role>>> GetAllRole()
    {
        var roles = await _roleRep.GetAsync();
        if(roles == null){
           return ReturnResult<List<Role>>.Error("当前没有任何角色，可以选择创建新角色");
        }
        return ReturnResult<List<Role>>.Success(roles);
    }

    // 获取角色名称
    public Role? GetByRoleName(string roleName)
    {
        var role = _roleRep.Table.FirstOrDefault(r => r.RoleName == roleName);
        return role;
    }

    // 获取指定id角色
    public async Task<ReturnResult<Role>> GetRoleById(Guid id)
    {
        var role = await _roleRep.GetByIdAsync(id);
        if(role == null){
          return ReturnResult<Role>.Error("该角色不存在");
        }
        if(role.IsDeleted == true){
          return ReturnResult<Role>.Error("该角色已被删除");
        }
        return ReturnResult<Role>.Success(role);
    }

    // 修改角色
    public async Task<ReturnResult<Role>> UpdateRole(Guid roleId, Role role)
    {
        var roleInfo = await _roleRep.GetByIdAsync(roleId);
        if(roleInfo == null){
          return ReturnResult<Role>.Error("该角色不存在");
        }
        roleInfo.RoleName = role.RoleName;
        roleInfo.Remark = role.Remark; 
        await _roleRep.UpdateAsync(roleInfo);
        return ReturnResult<Role>.Success(roleInfo);
    }
}