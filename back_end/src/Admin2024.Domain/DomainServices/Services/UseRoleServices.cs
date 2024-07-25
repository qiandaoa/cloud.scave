using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Services;
public class UseRoleServices:IUseRoleServices
{   

    private readonly IRepository<UserRole> repository;

    private readonly IRepository<User> userRep;
    private readonly IRepository<Role> roleRep;

    private readonly IToolRepository<UserRole> toolRepository;
    
    public UseRoleServices( IRepository<UserRole> _repository
     , IRepository<User> _userRep, IRepository<Role> _roleRep,IToolRepository<UserRole> _toolRepository
    )
    {
       
        repository=_repository;
        userRep=_userRep;
        roleRep=_roleRep;
        toolRepository=_toolRepository;
    }

    // 用户选择角色
    public async Task<ReturnResult<UserRole>> CreateUseRole(Guid useId,Guid roleId)
    {
       
        // 1.需要对id对应的实例是否存在做验证
        // 2.如果都存在，需要对id对应的领域对象做进一步验证，如状态验证（是否被删除、禁用等）和业务验证
        var user = await userRep.GetByIdAsync(useId);
        var role = await roleRep.GetByIdAsync(roleId);
        // 如果有用户和角色不存在
        if(user == null || role == null){
          return ReturnResult<UserRole>.Error("用户或角色不存在，请重试");
        }
        else if(user.IsDeleted || role.IsDeleted){
          return ReturnResult<UserRole>.Error("用户或角色已被删除，请重试");
        }
        else if(!user.IsActived || !role.IsActived){
          return ReturnResult<UserRole>.Error("用户或角色已被禁用，请重试");
        }
        // 如果角色已经被分配给用户
        var userRole = repository.Table.FirstOrDefault(x => x.UserId == useId && x.RoleId == roleId);
        if(userRole != null){
          return ReturnResult<UserRole>.Error("当前角色已经分配给当前用户，请重试");
        }
        var obj = new UserRole{UserId = useId, RoleId = roleId};
        var res = await repository.AddAsync(obj);
        return ReturnResult<UserRole>.Success(res);
    }

    // 移除用户角色
    public async Task<ReturnResult<UserRole>> DeleteUseRole(Guid useRoleId)
    {
        var fondExit=await repository.GetByIdAsync(useRoleId);
        if(fondExit==null)
        {
           return ReturnResult<UserRole>.Error("删除的目标不存在");
        }
        fondExit.IsDeleted=true;
        var getMsg=await repository.UpdateAsync(fondExit);
        if(getMsg!=null)
        {
           return ReturnResult<UserRole>.Success(getMsg);
        }
        return ReturnResult<UserRole>.Error("删除失败");
       
    }

    
      //分页查询
     public async Task<ReturnResult<List<UserRole>>> PagingUserRole(int? PageNumber, int? PageSize)
{       
  
        var getAll = await repository.GetAsync();
        var pagingVal= toolRepository.PagingAny(getAll, PageNumber, PageSize);
       if(pagingVal==null)
       {
          return ReturnResult<List<UserRole>>.Error("用户角色分页查询失败");
       }
        // 返回分页结果
        return ReturnResult<List<UserRole>>.Success(pagingVal);
}
   
}