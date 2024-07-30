
using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Application.Contracts.RoleApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.Helps;
using Admin2024.Instructions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin2024.Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{

  private readonly IRoleAppService _roleRep;
  private readonly IRolePermissionAssignDomainService _rolePer;
  public RoleController(IRoleAppService roleRep, IRolePermissionAssignDomainService rolePer)
  {
    _roleRep = roleRep;
    _rolePer = rolePer;
  }

  /// <summary>
  /// 获取指定id的角色
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet("{id}")]
  public async Task<ReturnResult<Role>> GetRoleById(Guid id)
  {
    return await _roleRep.GetRoleById(id);
  }

  /// <summary>
  /// 获取全部角色
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ReturnResult<List<Role>>> GetAllRole([FromQuery]BaseParameters baseParameters)
  {
    var roleList = await _roleRep.GetAllRole();
    var keywords = baseParameters.keywords;
    if(!string.IsNullOrEmpty(keywords)){
      var fileRole = roleList.Data.Where(r => r.RoleName.Contains(keywords)).ToList();
      return ReturnResult<List<Role>>.Success(fileRole);
    }
    return ReturnResult<List<Role>>.Success(roleList.Data);
  }

  /// <summary>
  /// 添加角色
  /// </summary>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<ReturnResult<Role>> AddRole(RoleCreateInfoDto input)
  {
    return await _roleRep.AddRole(input);
  }

  /// <summary>
  /// 删除角色(软删除)
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("{id}")]
  public async Task<ReturnResult<Role>> DeleteRole(Guid id)
  {
    return await _roleRep.DeleteRole(id);
  }

  /// <summary>
  /// 修改角色
  /// </summary>
  /// <param name="id"></param>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPut("{id}")]
  public async Task<ReturnResult<Role>> UpdateRole(Guid id, RoleUpdateInfoDto input)
  {
    return await _roleRep.UpdateRole(id, input);
  }

  /// <summary>
  /// 给角色分配权限
  /// </summary>
  /// <param name="roleId"></param>
  /// <param name="perId"></param>
  /// <returns></returns>
  [HttpPost("/api/RolePerAssign")]
  public async Task<ReturnResult<string>> AssignRolePermission(Guid roleId, Guid perId)
  {
    return await _rolePer.AssignRolePermission(roleId, perId);
  }
  
  /// <summary>
  /// 移除角色权限
  /// </summary>
  /// <param name="roleId"></param>
  /// <param name="perId"></param>
  /// <returns></returns>
  [HttpDelete("/api/RolePerAssign/")]
  public async Task<ReturnResult<string>> RemoveRolePermission(Guid roleId, Guid perId)
  {
    return await _rolePer.RemoveRolePermission(roleId, perId);
  }


}