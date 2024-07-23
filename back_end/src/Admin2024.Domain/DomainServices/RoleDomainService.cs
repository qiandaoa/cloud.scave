using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
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
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        await _roleRep.AddAsync(roleInfo);
#pragma warning restore CS8604 // 引用类型参数可能为 null。
        return ReturnResult<Role>.Success(roleInfo);
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

    public async Task<List<Role>> GetAllRole()
    {
        var roles = await _roleRep.GetAsync();
    }

    public Task<ReturnResult<Role>> GetRoleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ReturnResult<Role>> UpdateRole(Guid roleId, Role role)
    {
        throw new NotImplementedException();
    }
}