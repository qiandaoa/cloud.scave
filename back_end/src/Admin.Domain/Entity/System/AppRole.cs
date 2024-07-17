namespace Admin.Domain.Entity.System;
public class AppRole:BaseEntity
{
  // 初始化角色的权限列表
  private List<AppPermission> _appPermission = new List<AppPermission>();
  // 角色名
    public string RoleName { get; set;} = null!; 
  // 角色描述
  public string? Description { get; set;} = null!; 
  // 默认构造函数，一般用于ORM工具初始化对象
  public AppRole()
  {
  }
  public AppRole(string roleName,string description)
  {
    RoleName = roleName;
    Description = description;
  }
  // 分配权限
  public void AllocatePermission(AppPermission appPermission)
  {
    _appPermission.Add(appPermission);
  }
  // 移除权限
  public void RemovePermission(AppPermission appPermission)
  {
    _appPermission.Remove(appPermission);
  }
  // 判断有没有权限(包括资源和操作)
  public bool HasPermission(AppResource appResource,AppOperation appOperation)
  {
    return _appPermission.Any(p => p.AppResourceId == appResource.Id && p.AppOperationId == appOperation.Id);
  }
  public bool HasPermission(Guid resourceId,Guid operationId)
  {
    return _appPermission.Any(p => p.AppResourceId == resourceId && p.AppOperationId == operationId);
  }
}