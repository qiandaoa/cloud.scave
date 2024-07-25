using System.Globalization;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Services;
public class PermissionDomainService : IPermissionDomainService
{
    private readonly IRepository<Permission> _perRep;
    public PermissionDomainService(IRepository<Permission> perRep)
    {
        _perRep = perRep;
    }

    /// <summary>
    /// 添加权限
    /// </summary>
    /// <param name="permission"></param>
    /// <returns></returns>
    public async Task<ReturnResult<Permission>> AddPermission(Permission permission)
    {
       var IsExist = GetPermissionByName(permission.PermissionName);
       if(IsExist != null){
         return ReturnResult<Permission>.Error("该权限已存在");
       }
       var perCreate = await _perRep.AddAsync(permission);
       return ReturnResult<Permission>.Success(perCreate);
    }

    /// <summary>
    /// 获取全部权限
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<List<Permission>>> GetAllPermission()
    {
        var permissionList = await _perRep.GetAsync();
        if(permissionList == null){
            return ReturnResult<List<Permission>>.Error("权限列表为空");
        }
        return ReturnResult<List<Permission>>.Success(permissionList);
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    /// <param name="permissionName"></param>
    /// <returns></returns>
    public async Task<ReturnResult<Permission>> RemovePermission(Guid id)
    {
        var per = await _perRep.DeleteAsync(id);
        if(per == null){
            return ReturnResult<Permission>.Error("该权限不存在");
        }
        return ReturnResult<Permission>.Success(per);
    }

    /// <summary>
    /// 根据权限名称获取
    /// </summary>
    /// <param name="permissionName"></param>
    /// <returns></returns>
    public Permission? GetPermissionByName(string permissionName)
    {
        var per = _perRep.Table.FirstOrDefault(p => p.PermissionName == permissionName);
        return per;
    }

    /// <summary>
    /// 修改权限
    /// </summary>
    /// <param name="id"></param>
    /// <param name="permission"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Permission>> UpdatePermission(Guid id, Permission permission)
    {
        var perInfo = await _perRep.GetByIdAsync(id);
        if(perInfo == null){
            return ReturnResult<Permission>.Error("权限不存在");
        }
        perInfo.PermissionName = permission.PermissionName;
        perInfo.ResourceId = permission.ResourceId;
        perInfo.OperationId = permission.OperationId;
        await _perRep.UpdateAsync(perInfo);
        return ReturnResult<Permission>.Success(perInfo);
    }
}