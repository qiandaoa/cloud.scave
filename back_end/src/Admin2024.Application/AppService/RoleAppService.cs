using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Application.Contracts.RoleApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Application.AppService;
public class RoleApplication : IRoleAppService
{
    // 添加角色
    public Task<ReturnResult<Role>> AddRole(RoleCreateInfoDto input)
    {
        throw new NotImplementedException();
    }

    // 删除角色
    public Task<ReturnResult<Role>> DeleteRole(Guid roleId)
    {
        throw new NotImplementedException();
    }

    // 获取全部角色
    public Task<List<Role>> GetAllRole(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    // 获取指定id角色
    public Task<ReturnResult<Role>> GetRoleById(Guid id)
    {
        throw new NotImplementedException();
    }

    // 修改角色
    public Task<ReturnResult<Role>> UpdateRole(Guid roleId, RoleUpdateInfoDto input)
    {
        throw new NotImplementedException();
    }
}