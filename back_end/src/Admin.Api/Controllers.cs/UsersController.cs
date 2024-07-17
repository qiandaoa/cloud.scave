using Microsoft.AspNetCore.Mvc;
using Admin.Application.Contracts.AppUser;
using Admin.Domain.ObjectValue;
namespace Admin.Api.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class UsersController:ControllerBase
{
  private readonly IAppUserAppService _appUserAppService;
  public UsersController(IAppUserAppService appUserAppService)
  {
    _appUserAppService = appUserAppService;
  }
  [HttpGet]
  public IActionResult Get()
  {
      return Ok("11");
  }
 // 注册用户
  [HttpPost]
  public async Task<DomainResult<AppUserDto>> Post(CreateAppUserDto input)
  {
      var res = await _appUserAppService.Registry(input);
      return res;
  }
  // 登录路由
  [HttpPost("/api/login")]
  public dynamic? Post(LoginDto input)
  {
     var res = _appUserAppService.Login(input);
     return res;

  }
  [HttpPost("/api/assign")]
  public async Task<dynamic?> AssignRoleToUser([FromBody]AssigmRoleToUserDto input)
  {
     var res = await _appUserAppService.AllocateRoleToUser(input.AppUserId, input.AppRoleId);
     return new {res,Msg="Ok"};
  }
}