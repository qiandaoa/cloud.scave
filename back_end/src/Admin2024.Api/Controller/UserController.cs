using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.Helps;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace Admin2024.Api.Controller;
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
    /// <summary>
    /// 获取全部用户列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var entity = await _repo.GetAsync();
        return Ok(entity);
    }

    /// <summary>
    /// 获取指定id的用户
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
    /// 获取全部用户列表、进行关键字搜索、 分页
    /// </summary>
    /// <param name="baseParameters"></param>
    /// <returns></returns>
    [HttpGet(("/api/GetAllUsers"),Name = "GetAllUsers")]
    public ActionResult<List<User>> GetAllUser([FromQuery] BaseParameters baseParameters)
    {
        var users = _repo.Table;
        var keywords = baseParameters.keywords;
        // 进行关键字搜索
        if (!string.IsNullOrEmpty(keywords))
        {
            users = users.Where(x =>
              x.Username.Contains(keywords) ||
              x.NickName.Contains(keywords) ||
              x.Email.Contains(keywords) ||
              x.Telephone.Contains(keywords) ||
              x.Remark.Contains(keywords)
            );
        }
        var totalCount = users.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / baseParameters.PageSize);
        // 分页
        var list = users.Skip((baseParameters.PageIndex - 1) * baseParameters.PageSize)
                        .Take(baseParameters.PageSize).ToList();
        Pagination.GetPagination(baseParameters, totalPages, totalCount, Url, Response);
        var userList = _mapper.Map<List<User>>(list);
        return Ok(userList);
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="userCreateInfoDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddUser(UserCreateInfoDto userCreateInfoDto)
    {
        var creatUser = await _userAppService.UserAdd(userCreateInfoDto);
        if (creatUser == null)
        {
            return Ok("添加失败");
        }
        var userDto = _mapper.Map<User>(creatUser);
        return Ok(userDto);
    }
    /// <summary>
    /// 处理用户登录请求
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("/api/login")]
    public IActionResult UserLogin(LoginDto user)
    {
        var result = _userAppService.Login(user);
        Console.WriteLine(result);
        return result.IsSuccess  ? Ok(new { success = true, code = 200, data = new { token = result.Message ,Id = result.Data.Id}, msg = "登录成功!" }) : Unauthorized();
    }

    /// <summary>
    /// 注册用户
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
    /// 修改密码之前要对旧密码经行一次验证
    /// </summary>
    /// <param name="id"></param>
    /// <param name="oldPasswordDto"></param>
    /// <returns></returns>

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
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>

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
    /// <summary>
    /// 是否启用
    /// </summary>
    /// <param name="id"></param>
    /// <param name="or"></param>
    /// <returns></returns>
    [HttpPut("/api/actived/{id}")]
    public async Task<IActionResult> Actived(Guid id,bool or)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null)
        {
            return Ok("用户不存在");
        }
        // if ((entity.IsActived == false && or ==true) || (entity.IsActived == true && or == false))
        // {
        //     return entity.IsActived ? Ok("用户已经是启用状态,请更换bool值!!!!") : Ok("用户已经是禁用状态,请更换bool值！！！");
        // }
        await _repo.UpdateActiveState(id,or);
        return Ok(new { IsActived = entity.IsActived, code = 200, msg = $"用户状态已经更新:{entity.IsActived}"});
    }
    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userUpdateInfoDto"></param>
    /// <returns></returns>
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
        if (updateUser == null)
        {
            return Ok("修改失败");
        }
        var userDto = _mapper.Map<User>(entity);
        return Ok(userDto);
    }
    /// <summary>
    /// 删除用户（软删除）
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
}
