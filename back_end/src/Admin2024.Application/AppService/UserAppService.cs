using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using AutoMapper;
namespace Admin2024.Application.AppService;

public class UserAppService : IUserAppService
{
    private readonly IAuthServices _auth;
    private readonly IUserDomainService _userDomainService;
    private readonly IMapper _mapper;

    public UserAppService(IAuthServices auth,IMapper mapper,IUserDomainService userDomainService)
    {
        _auth = auth;
        _userDomainService = userDomainService;
        _mapper = mapper;
    }
    public ReturnResult<User> Login(LoginDto user)
    {
        var token =  _auth.Login(user.Username,user.Password);

        return token == null ? ReturnResult<User>.Error("登录失败!") : ReturnResult<User>.Success(token);
    }

    public async Task<ReturnResult<User>> Register(RegisterDto inputInfo)
    {
        if(string.IsNullOrEmpty(inputInfo.Username.Trim()) || string.IsNullOrEmpty(inputInfo.Password.Trim()))
        {
            return ReturnResult<User>.Error("用户名或密码不能为空!!");
        }
        if(inputInfo.Password != inputInfo.ConfirmPwd)
        {
            return ReturnResult<User>.Error("两次密码不一致,请重新输入!");
        }
        if(_userDomainService.GetByUsername(inputInfo.Username) != null)
        {
            return ReturnResult<User>.Error("该用户已存在!");
        }
        if(!User.ValidatePwd(inputInfo.Password))
        {
            return ReturnResult<User>.Error("密码格式有误!");
        }

        var user = _mapper.Map<RegisterDto,User>(inputInfo);
        await _userDomainService.Register(user);

        return ReturnResult<User>.Success("注册成功!");
    }

    public ReturnResult<User> VerifyPassword(Guid id, string oldPwd)
    {
        var user = _userDomainService.GetUserById(id);
        
        if(user == null)
        {
            return ReturnResult<User>.Error("未找到该用户!");
        }
        if(user.Password != oldPwd)
        {
            return ReturnResult<User>.Error("与旧密码不一致，请重新尝试!");
        }
        return ReturnResult<User>.Success("验证成功");
    }

    public async Task<ReturnResult<User>> ResetPassword(Guid id,ResetPasswordDto dto)
    {
        var user = _userDomainService.GetUserById(id);
        if(dto.NewPassword != dto.ConfirmNewPassword)
        {
            return ReturnResult<User>.Error("两次密码不一致，请重试!");
        }
        if(!User.ValidatePwd(dto.NewPassword))
        {
            return ReturnResult<User>.Error("密码格式不正确，请重试!");
        }
        _mapper.Map(dto,user);
        
#pragma warning disable CS8604 // 引用类型参数可能为 null。
        await _userDomainService.ResetPassword(user);
#pragma warning restore CS8604 // 引用类型参数可能为 null。

        return ReturnResult<User>.Success("重置成功!");

    }

}