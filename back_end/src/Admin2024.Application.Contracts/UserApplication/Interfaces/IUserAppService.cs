
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Application.Contracts.UserApplication.Interface;
public interface IUserAppService
{
    ReturnResult<User> Login(LoginDto user);
    Task<ReturnResult<User>> Register(RegisterDto inputInfo);
    ReturnResult<User> VerifyPassword(Guid id, string oldPwd);
    Task<ReturnResult<User>> ModifyPassword(Guid id, ModifyPasswordDto dto);

}