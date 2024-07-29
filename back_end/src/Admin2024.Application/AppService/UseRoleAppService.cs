
using Admin2024.Application.Contracts;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.System;
using Admin2024.EntityFramework;
using Admin2024.EntityFramework.Repositories;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Admin2024.Application.AppService;
  //由于未知前端需要的，所以返回string；
public class UseRoleAppService:IUseRoleAppService
{    
   
    private  readonly IUseRoleServices useRoleServices;
    private readonly AdminDbContext _dbContext;
    public UseRoleAppService( IUseRoleServices _roleServices, AdminDbContext dbContext )
    {
      
      useRoleServices = _roleServices;
      _dbContext = dbContext;
    }

    // 移除用户角色
    public async Task<ReturnResult<UserRole>> DeleteUseRole(Guid id)
    {
       var getVal=await useRoleServices.DeleteUseRole(id);
       return  getVal;
    }

    // 获取用户角色列表（连表）
    public List<UserWithRole> GetUserWithRole()
    {
        var useRoleList = _dbContext.Users // 将用户表作为主表
            .Join(_dbContext.UserRoles, user => user.Id,
                userRole => userRole.UserId,
                (user, userRole) => new { user, userRole })
            // join：第一个连接，连接用户角色表
            // user => user.Id，userRole => userRole.UserId：表示连接条件，将user中的id和userRole中的roleId取出并进行对比
            // (user, userRole) => new { user, userRole }：将user和userRole进行合并，生成一个新的对象
            .Join(_dbContext.Role, ur => ur.userRole.RoleId,
                role => role.Id,
                (ur, role) => new UserWithRole
                {
                    Id = ur.userRole.Id,
                    UserId = ur.user.Id,
                    RoleId = role.Id,
                    Username = ur.user.Username,
                    Nickname = ur.user.NickName,
                    Avatar = ur.user.Avatar,
                    Email = ur.user.Email,
                    Telephone = ur.user.Telephone,
                    RoleName = role.RoleName,
                    RoleRemark = role.Remark,
                    IsActived = ur.user.IsActived,
                    IsDeleted = ur.user.IsDeleted,
                    UserRoleIsDeleted = ur.userRole.IsDeleted
                })
            // join：第二个连接，连接上面的结果ur和角色表
            // (ur,role) => new UserRoleResult(...)：将用户表和角色表进行连接
            .ToList(); 
        return useRoleList;
    }

    // 获取用户角色列表（分页）
    public async Task<ReturnResult<List<UserRole>>> PagingGetRole(PagingRoleDto pagingRoleDto)
    {
        var getVal= await useRoleServices.PagingUserRole(pagingRoleDto.PageNumber, pagingRoleDto.PageSize);      
           return getVal;
        
       
    }

    //用户角色选择
    public async Task<ReturnResult<string>> SelectRole(CreateUseRoleDto createUseRoleDto)
    {  
        var getnew= await useRoleServices.CreateUseRole(createUseRoleDto.userid,createUseRoleDto.roleid);
        return  ReturnResult<string>.Success(getnew.Message);
    }

}