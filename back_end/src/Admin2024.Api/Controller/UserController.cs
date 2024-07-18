using Admin2024.Application.Contracts.UserApplication;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace Admin2024.Api;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _repo;
    private readonly IUserAppService _userAppService;
    public UserController(IRepository<User> repo, IUserAppService userAppService)
    {
        _repo = repo;
        _userAppService = userAppService;
    }
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var entity = await _repo.GetAsync();
        return Ok(entity);
    }
    /// <summary>
    /// 根据id获取拥护信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 根据id删除用户信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 登录功能
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("/api/login")]
    public IActionResult UserLogin(LoginDto user)
    {
        var result = _userAppService.Login(user);

        return result.IsSuccess ? Ok(new { success = true, code = 200, data = new { token = result.Message }, msg = "登录成功!" }) : Unauthorized();
    }
    /// <summary>
    /// 注册功能
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
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
    /// <summary>
    /// 对重置密码经行旧密码验证
    /// </summary>
    /// <param name="id"></param>
    /// <param name="oldPasswordDto"></param>
    /// <returns></returns>
    [HttpPost("/api/verify/{id}")]
    public IActionResult VerifyPassword(Guid id,[FromBody]VerifyPasswordDto oldPasswordDto)
    {
        var oldpwd = oldPasswordDto.OldPassword;
        var result = _userAppService.VerifyPassword(id, oldpwd);
        if (!result.IsSuccess)
        {
            return BadRequest(new { success = false, code = 400, msg = result.Message });
        }
        return Ok(new { success = true, code = 200, msg = result.Message });
    }

    /// <summary>
    /// 重置密码
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("/api/reset/{id}")]
    public async Task<IActionResult> ResetPassword(Guid id,ResetPasswordDto dto)
    {
        var result = await _userAppService.ResetPassword(id,dto);
        if (!result.IsSuccess)
        {
            return BadRequest(new { success = false, code = 400, msg = result.Message });
        }
        return Ok(new { success = true, code = 200, msg = result.Message });
    }
}
