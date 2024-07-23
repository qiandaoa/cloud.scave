using Admin2024.Instructions;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.System;

namespace Admin2024.Application.Contracts.UserApplication.Interface;

public interface IRoleAppService
{   
    
     //用户角色选择
     Task<ReturnResult<string>> SelectRole(CreateUseRoleDto createUseRoleDto);

     //用户角色的删除
     Task<ReturnResult<string>> DeleteUseRole(DelUseRoleDto deluseRoleId);

     //用户角色的查询
     Task<ReturnResult<List<UserRole>>> PagingGetRole(PagingRoleDto pagingRoleDto);
}