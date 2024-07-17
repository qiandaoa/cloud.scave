using Admin.Application.Contracts.AppUser;
using Admin.Domain.DomainService;
using Admin.Domain.ObjectValue;

namespace Admin.Application.AppUser;
public class AppUserAppService : IAppUserAppService
{
    private readonly IAuthDomainService _authDomainService;
    private readonly IAppUserDomainService _appUserDomainService;

    public AppUserAppService(IAuthDomainService authDomainService,IAppUserDomainService appUserDomainService)
    {
        _authDomainService = authDomainService;
        _appUserDomainService = appUserDomainService;
    }
    public async Task<AssignUsertoRoleResultDto?> AllocateRoleToUser(Guid appUserId, Guid appRoleId)
    {
        var dto = await _appUserDomainService.AssigmRoleToUser(appUserId, appRoleId);
        var res = dto != null ? new AssignUsertoRoleResultDto{AppUserId = appUserId,AppRoleId = appRoleId}:null;
        return res;
    }

    public void BannedUser()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    // 用户登录
    // public string? Login(LoginDto input)
    // {
    //     var res = _authDomainService.Login(input.Username,input.Password);
    //     return res.IsSuccess ? res.Data:null;
    // }

    public DomainResult<AppUserDto> Login(LoginDto input)
    {
        var res = _appUserDomainService.Login(input.Username, input.Password);
        if(res.IsSuccess){
           var data = res.Data;
           var dto = new AppUserDto{Id = data.Id, UserName = data.UserName};
           return DomainResult<AppUserDto>.Success(dto);
        }
         return DomainResult<AppUserDto>.Error(res.ErrorMessage);
    }

    public void Logout(string token)
    {
        throw new NotImplementedException();
    }

    public void ModifyPwd(string password)
    {
        throw new NotImplementedException();
    }

    public async Task<DomainResult<AppUserDto>> Registry(CreateAppUserDto input)
    {
        // 调用领域层的领域服务
       var res = await _appUserDomainService.Create(input.UserName,input.Password,input.ConfirmPassword);
        // 如果领域服务调用成功,则创建一个对象
       if(res.IsSuccess){
        var dto = new AppUserDto{Id = res.Data.Id,UserName = res.Data.UserName};
        // 返回一个成功的 DomainResult，包含成功创建的用户信息
        return DomainResult<AppUserDto>.Success(dto);
       }
       return DomainResult<AppUserDto>.Error(res.ErrorMessage);
    }

    public void Update(UpdateAppUserDto updateAppUserDto)
    {
        throw new NotImplementedException();
    }
}
