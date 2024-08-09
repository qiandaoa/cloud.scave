
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.EntityFramework;
using Admin2024.EntityFramework.Helps;
using Admin2024.EntityFramework.Repositories;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc;
namespace Admin2024.Api.Controller;


[ApiController]
[Route("/api/[controller]")]
public class UseRoleController : ControllerBase
{

     private readonly IUseRoleAppService _useRoleAppService;

     public UseRoleController(IUseRoleAppService useRoleAppService)
     {
         _useRoleAppService = useRoleAppService;
         
     }
    /// <summary>
    /// 删除用户角色
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
     [HttpDelete("{id}")]
     public async Task<ReturnResult<UserRole>> DeleteUseRole(Guid id)
     {
        //  var getmgs = await _useRoleAppService.DeleteUseRole(deluseRoleId);
        //  return getmgs;
        return await _useRoleAppService.DeleteUseRole(id);
     }

   

     /// <summary>
     /// 用户的角色选择
     /// </summary>
     /// <param name="createRoleDto"></param>
     /// <returns></returns>
     [HttpPost("createuserole")]
     public async Task<IActionResult>  CreateUseRole([FromBody]  CreateUseRoleDto createRoleDto)
     {
         var getmgs = await _useRoleAppService.SelectRole(createRoleDto);
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
         return await  _useRoleAppService.PagingGetRole(pagingRoleDto);
         
     }

     /// <summary>
     /// 用户角色的连表查询(带模糊查询)
     /// </summary>
     /// <returns></returns>
     [HttpGet]
     public IActionResult GetUseRole([FromQuery]BaseParameters baseParameters)
     {
        var list = _useRoleAppService.GetUserWithRole();
        var keywords = baseParameters.keywords;
        if(!string.IsNullOrEmpty(keywords)){
            var filer = list.Where(u => u.Username.Contains(keywords)).ToList();
            return Ok(filer);
        }
        return Ok(list);
     }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserRole(Guid Id) 
    {
        var list = _useRoleAppService.GetUserWithRole();
        var entity = list.Where(u => u.UserId == Id);
        return Ok(entity);
    }

}