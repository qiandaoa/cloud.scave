using Microsoft.AspNetCore.Mvc;
using Admin.Application.Contracts.AppUser;
using Admin.Domain.ObjectValue;
namespace Admin.Api.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
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
    //1、第一次登录的时候，前端调后端的登陆接口，发送用户名和密码
    //2、后端收到请求，验证用户名和密码，验证成功，就给前端返回一个token
    //3、前端拿到token，将token存储到localStorage和vuex中，并跳转路由页面
    //4、前端每次跳转路由，就判断 localStroage 中有无 token ，没有就跳转到登录页面，有则跳转到对应路由页面
    //5、每次调后端接口，都要在请求头中加token
    //6、后端判断请求头中有无token，有token，就拿到token并验证token，验证成功就返回数据，验证失败（例如：token过期）就返回401，请求头中没有token也返回401
    //7、如果前端拿到状态码为401，就清除token信息并跳转到登录页面
    // 登录路由
    [HttpPost("/api/login")]
    public dynamic? Post(LoginDto input)
    {
        var res = _appUserAppService.Login(input);
        return res;

    }
    [HttpPost("/api/assign")]
    public async Task<dynamic?> AssignRoleToUser([FromBody] AssigmRoleToUserDto input)
    {
        var res = await _appUserAppService.AllocateRoleToUser(input.AppUserId, input.AppRoleId);
        return new { res, Msg = "Ok" };
    }
}