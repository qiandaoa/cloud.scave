using Admin2024.Application.Contracts.RoleApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Instructions;

namespace Admin2024.Application.AppService;
public class RolePermissionAssignAppService : IRolePermissionAssignAppService
{
    private readonly IRolePermissionAssignDomainService _rolePer;
    public RolePermissionAssignAppService(IRolePermissionAssignDomainService rolePer)
    {
        _rolePer = rolePer;
    }
    // 给用户分配权限 
    public async Task<ReturnResult<string>> AssignRolePermission(Guid roleId, Guid perId)
    {
        var rolePer = await _rolePer.AssignRolePermission(roleId, perId);
        if(!rolePer.IsSuccess){
          return ReturnResult<string>.Error(rolePer.Message);
        }
        return ReturnResult<string>.Success(rolePer.Message);
    }

    // 移除用户权限
    public async Task<ReturnResult<string>> RemoveRolePermission(Guid roleId, Guid perId)
    {
        var rolePer = await _rolePer.RemoveRolePermission(roleId, perId);
        if(!rolePer.IsSuccess){
          return ReturnResult<string>.Error(rolePer.Message);
        }
        return ReturnResult<string>.Success(rolePer.Message);
    }
}