using Admin2024.Instructions;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.Repositories;

namespace Admin2024.Application.Contracts.UserApplication.Interface;

public interface IUseRoleAppService
{   
    
     //用户角色选择
     Task<ReturnResult<string>> SelectRole(CreateUseRoleDto createUseRoleDto);

     //用户角色的删除
     Task<ReturnResult<string>> DeleteUseRole(DelUseRoleDto deluseRoleId);

     //用户角色的查询
     Task<ReturnResult<List<UserRole>>> PagingGetRole(PagingRoleDto pagingRoleDto);

     //用户角色的连表查询
     List<UserWithRole> GetUserWithRole();
}