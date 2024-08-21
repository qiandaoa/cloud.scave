using Admin2024.Domain.System;

public interface IInquireRepository
{
    //通用的权限系统

    //用户表的查询
    Task<List<User>> InquireUse(string? keyword);
    //角色表的查询
    Task<List<Role>> InquireRole(string? keyword);
    //用户角色配置表查询
    Task<List<UserRole>> InquireUseRole(string? keyword);
    //用户权限表查询
    Task<List<RolePermission>> InquireRolePermisson(string? keyword);
    //菜单操作表查询
    Task<List<Permission>> InquirePermisson(string? keyword);
    //菜单表查询
    Task<List<Resource>> InquireResource(string? keyword);
    //操作表的查询
    Task<List<Operation>> InquirePermiss(string? keyword);



}