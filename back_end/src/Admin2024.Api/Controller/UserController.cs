using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Admin2024.Api;
[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _repo;
    private readonly IUserAppService _userAppService;
    private readonly IMapper _mapper;
    public UserController(IRepository<User> repo, IUserAppService userAppService,IMapper mapper)
    {
        _repo = repo;
        _userAppService = userAppService;
        _mapper = mapper;
    }
    // 获取全部用户列表
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var entity = await _repo.GetAsync();
        return Ok(entity);
    }

    // 获取指定id的用户
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    // 删除用户（软删除）
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        await _repo.DeleteAsync(id);
        return Ok(entity);
    }

    // 修改用户信息
    [HttpPut("/api/UserUpdate/{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserUpdateInfoDto userUpdateInfoDto)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
        {
            return Ok("查找不到用户，修改失败");
        }
        _mapper.Map(userUpdateInfoDto, entity);
        var updateUser = await _repo.UpdateAsync(entity);
        if(updateUser == null){
            return Ok("修改失败");
        }
        var userDto = _mapper.Map<User>(entity);
        return Ok(userDto);
    }

    // 处理用户登录请求
    [HttpPost("/api/login")]
    public IActionResult UserLogin(LoginDto user)
    {
        var result = _userAppService.Login(user);

        return result.IsSuccess  ? Ok(new { success = true, code = 200, data = new { token = result.Message }, msg = "登录成功!" }) : Unauthorized();
    }

    // 注册用户
    [HttpPost("/api/register")]
    public async Task<IActionResult> RegisterAccount(RegisterDto info)
    {
        var result = await _userAppService.Register(info);

        if (!result.IsSuccess)
        {
            return BadRequest(new { success = false, code = 400, msg = result.Message });
        }
        return Ok(new { success = true, code = 200, msg = result.Message });
    }


    [HttpPost("/api/verify/{id}")]
    public IActionResult VerifyPassword(Guid id, [FromBody] VerifyPasswordDto oldPasswordDto)
    {
        var oldpwd = oldPasswordDto.OldPassword;
        var result = _userAppService.VerifyPassword(id, oldpwd);
        if (!result.IsSuccess)
        {
            return BadRequest(new { success = false, code = 400, msg = result.Message });
        }
        return Ok(new { success = true, code = 200, msg = result.Message });
    }


    [HttpPut("/api/modify/{id}")]
    public async Task<IActionResult> ModifyPassword(Guid id, ModifyPasswordDto dto)
    {
        var result = await _userAppService.ModifyPassword(id, dto);
        if (!result.IsSuccess)
        {
            return BadRequest(new { success = false, code = 400, msg = result.Message });
        }
        return Ok(new { success = true, code = 200, msg = result.Message });
    }
}
