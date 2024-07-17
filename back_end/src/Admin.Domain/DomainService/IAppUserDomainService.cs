using Admin.Domain.Entity.System;
using Admin.Domain.ObjectValue;

namespace Admin.Domain.DomainService;
public interface IAppUserDomainService
{
  // 修改密码
  void ModifyPassword(Guid id,string password);
  // 登录
  DomainResult<AppUser> Login(string username,string password);
  // 创建用户/注册
  Task<DomainResult<AppUser>> Create(string username,string password,string confirmPassword);
  // 分配角色
  Task<DomainResult<AppUserRole>> AssigmRoleToUser(Guid appUserId, Guid appRoleId);
  bool DeleteUser(AppUser user);
  bool DeleteUser(Guid id);

  DomainResult<AppUser> GetUserByUsername(string username);
}