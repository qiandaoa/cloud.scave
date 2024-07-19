using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using AutoMapper;

namespace Admin2024.Application.AppService;

public class UserAppService : IUserAppService
{
    private readonly IAuthServices _auth;
    private readonly IUserDomainService _userDomainService;
    private readonly IMapper _mapper;

    public UserAppService(IAuthServices auth, IMapper mapper, IUserDomainService userDomainService)
    {
        _auth = auth;
        _userDomainService = userDomainService;
        _mapper = mapper;
    }
    public ReturnResult<User> Login(LoginDto user)
    {
        // 先在数据库中查找用户是否存在
        var loginUser = _userDomainService.GetByUsername(user.Username);
        if (loginUser == null)
        {
            return ReturnResult<User>.Error("用户名或密码错误!");
        }

        // 若是存在，取出该用户名的盐，与进行登录操作的用户输入的密码哈希
        var salt = loginUser.Salt;
        var hashLoginDtoPassword = PasswordHelper.HashPassword(user.Password, salt);

        // 将进行登录操作的用户输入的密码哈希后
        // 和该用户名数据库中哈希后的密码对比，若是不对，返回用户名或密码错误
        if (loginUser.Password != hashLoginDtoPassword)
        {
            return ReturnResult<User>.Error("用户名或密码错误!");
        }

        // 密码匹配，继续登录操作，获取token
        var token = _auth.Login(loginUser);

        return token == null ? ReturnResult<User>.Error("登录失败!") : ReturnResult<User>.Success(token);
    }

    public async Task<ReturnResult<User>> Register(RegisterDto inputInfo)
    {
        // 判断用户名和密码是否有留空
        if (string.IsNullOrEmpty(inputInfo.Username.Trim()) || string.IsNullOrEmpty(inputInfo.Password.Trim()))
        {
            return ReturnResult<User>.Error("用户名或密码不能为空!!");
        }

        // 判断两次密码是否一致
        if (inputInfo.Password != inputInfo.ConfirmPwd)
        {
            return ReturnResult<User>.Error("两次密码不一致,请重新输入!");
        }

        // 判断注册的用户名是否被注册过
        if (_userDomainService.GetByUsername(inputInfo.Username) != null)
        {
            return ReturnResult<User>.Error("该用户已存在!");
        }

        // 判断密码格式是否符合规定
        if (!User.ValidatePwd(inputInfo.Password))
        {
            return ReturnResult<User>.Error("密码格式有误!");
        }

        // 通过以上异常处理，继续进行注册操作

        // 将Dto类型映射为实体类型
        var user = _mapper.Map<RegisterDto, User>(inputInfo);

        // 注册操作
        await _userDomainService.Register(user);

        return ReturnResult<User>.Success("注册成功!");
    }

    // 修改密码前验证旧密码
    public ReturnResult<User> VerifyPassword(Guid id, string inputPwd)
    {
        // 在数据库中查找该用户是否存在
        var user = _userDomainService.GetUserById(id);
        if (user == null)
        {
            return ReturnResult<User>.Error("未找到该用户!");
        }

        // 若存在取出盐，和输入的密码哈希后与该用户数据库中哈希后的密码对比
        var salt = user.Salt;
        var hashInputPwd = PasswordHelper.HashPassword(inputPwd, salt);
        if (user.Password != hashInputPwd)
        {
            return ReturnResult<User>.Error("与旧密码不一致，请重新尝试!");
        }
        return ReturnResult<User>.Success("验证成功");
    }
    // 通过以上验证，前端才能跳转到下面的修改密码页面

    // 修改密码
    public async Task<ReturnResult<User>> ModifyPassword(Guid id, ModifyPasswordDto dto)
    {
        var user = _userDomainService.GetUserById(id);

        // 确保修改的密码符合规范
        if (dto.NewPassword != dto.ConfirmNewPassword)
        {
            return ReturnResult<User>.Error("两次密码不一致，请重试!");
        }
        if (!User.ValidatePwd(dto.NewPassword))
        {
            return ReturnResult<User>.Error("密码格式不正确，请重试!");
        }

        // 以上验证通过后，取出盐，与新密码哈希后储存
        _mapper.Map(dto, user);
        var salt = user.Salt;
        user.Password = PasswordHelper.HashPassword(dto.NewPassword, salt);

#pragma warning disable CS8604 // 引用类型参数可能为 null。
        // 修改密码操作
        await _userDomainService.ModifyPassword(user);
#pragma warning restore CS8604 // 引用类型参数可能为 null。

        return ReturnResult<User>.Success("重置成功!");

    }
}