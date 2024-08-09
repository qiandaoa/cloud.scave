using Admin2024.Application.Contracts;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Microsoft.AspNetCore.Mvc;

namespace Admin2024.Api.Controller;
[ApiController]
[Route("/api/[controller]")]
public class UserPermissionController : ControllerBase
{
    private IRepository<User> _user;
    private IRepository<Role> _role;
    private IRepository<Permission> _permission;
    private IRepository<UserRole> _userRole;
    private IRepository<RolePermission> _rolepermission;
    public UserPermissionController(IRepository<User> user, IRepository<Role> role, IRepository<Permission> permission,
    IRepository<UserRole> userRole, IRepository<RolePermission> rolepermission)
    {
        _user = user;
        _role = role;
        _permission = permission;
        _userRole = userRole;
        _rolepermission = rolepermission;
    }
    [HttpGet("{username}")]
    public IActionResult GetUserPermission([FromRoute] string username)
    {
        var user = _user.Table.FirstOrDefault(x => x.Username == username);
        if (user == null)
        {
            return Ok("找不到该用户");
        }
        var userRoleIds = _userRole.Table.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
        var RoleNames = _role.Table.Where(x => userRoleIds.Contains(x.Id)).Select(x => x.RoleName).ToList();
        var userRoleNames = new List<string>();
        foreach (var item in RoleNames)
        {
            userRoleNames.Add(item);
        }

        var rolePermissionIds = _rolepermission.Table.Where(x => userRoleIds.Contains(x.RoleId)).Select(x => x.PermissionId).ToList();
        var PermissionNames = _permission.Table.Where(x => rolePermissionIds.Contains(x.Id)).Select(x => x.PermissionName).ToList();
        var rolePermissionNames = new List<string>();
        foreach (var item in PermissionNames)
        {
            rolePermissionNames.Add(item);
        }

        var userRolePermission = new UserPermissionDto
        {
            UserId = user.Id,
            Username = user.Username,
            RoleName = userRoleNames, // 直接使用List<string>
            PermissionName = rolePermissionNames, // 直接使用List<string>
        };
        return Ok(userRolePermission);
    }
}