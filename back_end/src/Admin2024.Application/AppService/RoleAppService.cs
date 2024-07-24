
using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Application.Contracts.RoleApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using AutoMapper;

namespace Admin2024.Application.AppService;
public class RoleAppService : IRoleAppService
{
    private readonly IRoleDomainService _roleDomainService;
    private readonly IMapper _mapper;
    public RoleAppService(IRoleDomainService roleDomainService, IMapper mapper)
    {
      _roleDomainService = roleDomainService;
      _mapper = mapper;
    }
    // 添加角色
    public async Task<ReturnResult<Role>> AddRole(RoleCreateInfoDto input)
    {
        // 判断角色名称是否为空
        if(string.IsNullOrEmpty(input.RoleName)){
          return ReturnResult<Role>.Error("角色名称不能为空");
        }
        if(_roleDomainService.GetByRoleName(input.RoleName) != null){
          return ReturnResult<Role>.Error("角色已存在");
        }

        var roleDto = _mapper.Map<RoleCreateInfoDto,Role>(input);
        await _roleDomainService.AddRole(roleDto);
        return ReturnResult<Role>.Success(roleDto);
    }

    // 删除角色
    public async Task<ReturnResult<Role>> DeleteRole(Guid roleId)
    {
        var role = await _roleDomainService.GetRoleById(roleId);
        if(role == null){
          return ReturnResult<Role>.Error("角色不存在");
        }
        await _roleDomainService.DeleteRole(roleId);
        return ReturnResult<Role>.Success("删除成功");
    }

    // 获取全部角色
    public async Task<ReturnResult<List<Role>>> GetAllRole()
    {
        var roles = await _roleDomainService.GetAllRole();
        return ReturnResult<List<Role>>.Success(roles.Data);
    }


    // 获取指定id角色
    public Task<ReturnResult<Role>> GetRoleById(Guid id)
    {
        var role = _roleDomainService.GetRoleById(id);
        if(role == null){
          return Task.FromResult(ReturnResult<Role>.Error("角色不存在"));
        }
        return role;
    }

    // 修改角色
    public async Task<ReturnResult<Role>> UpdateRole(Guid roleId, RoleUpdateInfoDto input)
    {
       var role = _mapper.Map<RoleUpdateInfoDto,Role>(input);
       var roleUpdate = await _roleDomainService.UpdateRole(roleId,role);
       if(!roleUpdate.IsSuccess){
         return ReturnResult<Role>.Error("修改失败");
       }
       var roleDto = _mapper.Map<Role>(roleUpdate.Data);
       return ReturnResult<Role>.Success(roleDto);
    }
}