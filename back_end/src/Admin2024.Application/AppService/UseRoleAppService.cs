
using Admin2024.Application.Contracts;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Admin2024.Application.AppService;
  //由于未知前端需要的，所以返回string；
public class UseRoleAppService:IUseRoleAppService
{    
   
    private  readonly IUseRoleServices useRoleServices;
    public UseRoleAppService( IUseRoleServices _roleServices)
    {
      
      useRoleServices = _roleServices;
    }

    public async Task<ReturnResult<string>> DeleteUseRole(DelUseRoleDto deluseRoleId)
    {
       var getVal=await useRoleServices.DeleteUseRole(deluseRoleId.UseroleId);
       return  ReturnResult<string>.Success(getVal.Message);
    }

    public async Task<ReturnResult<List<UserRole>>> PagingGetRole(PagingRoleDto pagingRoleDto)
    {
        var getVal= await useRoleServices.PagingUserRole(pagingRoleDto.PageNumber, pagingRoleDto.PageSize);      
           return getVal;
        
       
    }




    //用户角色选择
    public async Task<ReturnResult<string>> SelectRole(CreateUseRoleDto createUseRoleDto)
    {  
        var getnew= await useRoleServices.CreateUseRole(createUseRoleDto.userid,createUseRoleDto.roleid);
        return  ReturnResult<string>.Success(getnew.Message);
    }

}