using Admin.Domain.ObjectValue;

namespace Admin.Application.Contracts.AppUser;
public interface IAppUserAppService
{
  // 注册功能
  Task<DomainResult<AppUserDto>> Registry(CreateAppUserDto createAppUserDto);
  // 登录功能
  DomainResult<AppUserDto> Login(LoginDto input);
  // string? Login(LoginDto input);
  // 登出功能
  void Logout(string token);
  // 禁用功能
  void BannedUser();
  // 删除功能
  void Delete();
  // 修改用户基本信息
  void Update(UpdateAppUserDto updateAppUserDto);
  // 修改密码
  void ModifyPwd(string password);
  // 管理用户角色
  Task<AssignUsertoRoleResultDto?> AllocateRoleToUser(Guid appUserId,Guid appRoleId);
}