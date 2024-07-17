using Admin.Domain.Entity.System;
using Admin.Domain.Interface;
using Admin.Domain.ObjectValue;

namespace Admin.Domain.DomainService;
public class AppUserDomainService:IAppUserDomainService
{
    private readonly IRepository<AppUser> _appUserRepository;
    private readonly IRepository<AppRole> _appRoleRepository;
    private readonly IRepository<AppUserRole> _appUserRoleRepository;
    public AppUserDomainService(
      IRepository<AppUser> appUserRepository,
      IRepository<AppRole> appRoleRepository,
      IRepository<AppUserRole> appUserRoleRepository)
    {
      _appUserRepository = appUserRepository;
      _appRoleRepository = appRoleRepository;
      _appUserRoleRepository = appUserRoleRepository;
    }

    // 给用户分配角色
    public async Task<DomainResult<AppUserRole>> AssigmRoleToUser(Guid appUserId, Guid appRoleId)
    {
        // 1.需要对id对应的实例是否存在做验证
        // 2.如果都存在，需要对id对应的领域对象做进一步验证，如状态验证（是否被删除、禁用等）和业务验证
        var user = await _appUserRepository.GetByIdAsync(appUserId);
        var role = await _appRoleRepository.GetByIdAsync(appRoleId);
        // 如果有用户和角色不存在
        if(user == null || role == null){
          return DomainResult<AppUserRole>.Error("用户或角色不存在，请重试");
        }
        else if(user.IsDeleted || role.IsDeleted){
          return DomainResult<AppUserRole>.Error("用户或角色已被删除，请重试");
        }
        else if(!user.IsActived || !role.IsActived){
          return DomainResult<AppUserRole>.Error("用户或角色已被禁用，请重试");
        }
        // 如果角色已经被分配给用户
        var userRole = _appUserRoleRepository.Table.FirstOrDefault(x => x.AppUserId == appUserId && x.AppRoleId == appRoleId);
        if(userRole != null){
          return DomainResult<AppUserRole>.Error("当前角色已经分配给当前用户，请重试");
        }
        var obj = new AppUserRole{AppUserId = appUserId, AppRoleId = appRoleId};
        var res = await _appUserRoleRepository.CreateAsync(obj);
        return DomainResult<AppUserRole>.Success(res);
    }

    // 创建用户
    public async Task<DomainResult<AppUser>> Create(string username, string password, string confirmPassword)
    {
        // 去除用户名和密码的前后空格
        username = username.Trim();
        password = password.Trim();
        confirmPassword = confirmPassword.Trim();

        // 根据用户名去查找数据库有无对应的用户名记录，如果有，则说明该用户名重复
        var user = _appUserRepository.Table.FirstOrDefault(x => x.UserName == username);
        if(user != null){
          return DomainResult<AppUser>.Error("用户名已存在");
        }
        // 如果没有找到就创建新用户（要求：用户名长度和密码长度符合>=5且<=30)
        if(!(username.Length >= 5 && username.Length <= 30)){
          return DomainResult<AppUser>.Error("用户名长度不符合规范，请重试设置");
        }
        if(!(password.Length >= 5 && password.Length <= 30)){
          return DomainResult<AppUser>.Error("密码长度不符合规范，请重试设置");
        }
        if(password != confirmPassword){
          return DomainResult<AppUser>.Error("两次密码输入不一致，请重新输入");
        }
        // 符合所有要求就创建用户
        var appUser = new AppUser{UserName = username, Password = password,Salt="随便吧"};
        var res = await _appUserRepository.CreateAsync(appUser);
        if(res == null){
          return DomainResult<AppUser>.Error("创建失败");
        }
        return DomainResult<AppUser>.Success(res);
    }

    // 删除用户（根据实体）
    public bool DeleteUser(AppUser user)
    {
        throw new NotImplementedException();
    }

    // 删除用户（根据id）
    public bool DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    // 查找用户名 
    public DomainResult<AppUser> GetUserByUsername(string username)
    {
        var user = _appUserRepository.Table.FirstOrDefault(x => x.UserName == username);
        if(user == null){
          return DomainResult<AppUser>.Error("用户名不存在");
        }
        return DomainResult<AppUser>.Success(user);
    }

    public void Haspemission(AppPermission appPermission)
    {
        throw new NotImplementedException();
    }

    public DomainResult<AppUser> Login(string username, string password)
    {
        // 根据用户名查找是否存在对应用户
        var user = _appUserRepository.Table.FirstOrDefault(x => x.UserName == username);
        // 1.未找到用户
        if(user == null){
          return DomainResult<AppUser>.Error("用户名或密码不正确，请确认后重试");
        }
        // 2.找到：已被删除，已被禁用
        if(user.IsDeleted){
          return DomainResult<AppUser>.Error("用户名已被删除，请确认后重试");
        }
        if(!user.IsActived){
          return DomainResult<AppUser>.Error("用户名已被禁用，请确认后重试");
        }
        if(user.Password != password){
          return DomainResult<AppUser>.Error("用户名或密码不正确，请确认后重试");
        }
        return DomainResult<AppUser>.Success(user);
    }

    // 修改密码，大部分操作在领域类型中完成的，如md5加密，base64加密
    // 领域服务中，仅仅只是完成持久化（保存到数据库）
    public async void ModifyPassword(Guid id, string password)
    {
        var user = await _appUserRepository.GetByIdAsync(id);
        if(user != null){
          // 真正修改密码，其实是在领域模型中完成
          user.ModifyPassword(password);
          var res = await _appUserRepository.UpdateAsync(user);
        }
        
    }
}