using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc;
namespace Admin2024.Api.Controller;

[ApiController]
[Route("/api/[controller]")]
public class RoleController : ControllerBase
{
     private readonly IRoleAppService roleAppService;
     public RoleController(IRoleAppService _roleAppService)
     {
         roleAppService=_roleAppService;
     }

     [HttpPost("deleteuserole")]
        public async Task<IActionResult> DeleteUseRole([FromBody] DelUseRoleDto deluseRoleId)
        {
            var getmgs = await roleAppService.DeleteUseRole(deluseRoleId);
            return Ok(getmgs);
        }

   

     //用户的角色选择
     [HttpPost("createuserole")]
     public async Task<IActionResult>  CreateUseRole([FromBody]  CreateUseRoleDto createRoleDto)
     {
         var getmgs = await roleAppService.SelectRole(createRoleDto);
         return Ok(getmgs);
     }
     

     //分页查询
     [HttpPost("pagingRole")]
     public async Task<ReturnResult<List<UserRole>>> PagingGetRole([FromBody]PagingRoleDto pagingRoleDto)
     {
         return await  roleAppService.PagingGetRole(pagingRoleDto);
         
     }
}