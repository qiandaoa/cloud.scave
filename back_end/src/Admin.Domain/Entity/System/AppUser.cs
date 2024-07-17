
using System.Text;

namespace Admin.Domain.Entity.System;
// 这里加App只是为了防止User与应用程序中的某些名词发生冲突
public class AppUser:BaseEntity
{
  // 初始化用户的角色列表
  private List<AppRole> _appRoles = new List<AppRole>(); 
  public string UserName { get; set;} = null!; // 用户名
  public string Password { get; set;} = null!; // 密码
  public string Salt { get; set;} = null!; // 盐 随机加密字符串
  public string? NickName { get; set;} // 昵称
  public string? Avatar { get; set;} // 头像
  public string? Tel { get; set;} // 手机号
  public string? Weixin { get; set;} // 微信
  public string? QQ { get; set;} // QQ

  // 注册
  public void Registry()
  {
    var usernamr = this.UserName.Trim();
    // 判断用户名不能为空，且长度大于等于5
    if(!string.IsNullOrEmpty(usernamr) && usernamr.Length >= 5)
    {
      this.UserName = usernamr;
    }
    var pwdTypes = Encoding.UTF8.GetBytes(Password);
    this.Password = Convert.ToBase64String(pwdTypes);
  }
  // 设置密码
  internal void ModifyPassword(string password)
  {
      this.Password = password;
  }
  // 分配角色
  public void AllocateRole(AppRole appRole)
  {
      _appRoles.Add(appRole);
  }
  // 移除角色
  public void RemoveRole(AppRole appRole)
  {
      _appRoles.Remove(appRole);
  }
   public void RemoveRole(string roleName)
  {
      var role = _appRoles.FirstOrDefault(r => r.RoleName == roleName);
      if(role != null){
        _appRoles.Remove(role);
      }
      
  }
  // 判断是否有权限
  public bool HasPermission(string res)
  {
      return true;//暂定true
  }
  public bool ValidatePassword(string password)
  {
    return this != null && Password != null && Password.Length > 0 && Password.Equals(password);
  }

}
