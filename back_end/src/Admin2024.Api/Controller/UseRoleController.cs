
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc;
namespace Admin2024.Api.Controller;


[ApiController]
[Route("/api/[controller]")]
public class UseRoleController : ControllerBase
{

     private readonly IUseRoleAppService roleAppService;
     public UseRoleController(IUseRoleAppService _roleAppService)
     {
         roleAppService=_roleAppService;
     }
    /// <summary>
    /// 删除用户角色
    /// </summary>
    /// <param name="deluseRoleId"></param>
    /// <returns></returns>
     [HttpPost("deleteuserole")]
        public async Task<IActionResult> DeleteUseRole([FromBody] DelUseRoleDto deluseRoleId)
        {
            var getmgs = await roleAppService.DeleteUseRole(deluseRoleId);
            return Ok(getmgs);
        }

   

     /// <summary>
     /// 用户的角色选择
     /// </summary>
     /// <param name="createRoleDto"></param>
     /// <returns></returns>
     [HttpPost("createuserole")]
     public async Task<IActionResult>  CreateUseRole([FromBody]  CreateUseRoleDto createRoleDto)
     {
         var getmgs = await roleAppService.SelectRole(createRoleDto);
         return Ok(getmgs);
     }
     

     /// <summary>
     /// 分页查询
     /// </summary>
     /// <param name="pagingRoleDto"></param>
     /// <returns></returns>
     [HttpPost("pagingRole")]
     public async Task<ReturnResult<List<UserRole>>> PagingGetRole([FromBody]PagingRoleDto pagingRoleDto)
     {
         return await  roleAppService.PagingGetRole(pagingRoleDto);
         
     }


}