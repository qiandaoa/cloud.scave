using Admin2024.Application.Contracts.PermissionApplication.Dto;
using Admin2024.Application.Contracts.PermissionApplication.Interface;
using Admin2024.Domain.DomainServices.Interface;

using Admin2024.Domain.System;
using Admin2024.Instructions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


public class PermissionAppService : IPermissionAppService
{
     private readonly IPermissionDomainService _per;
     private readonly IOperationServices _ope;
     private readonly IResourceDomainService _res;
     private readonly IMapper _mapper;

     public PermissionAppService(IPermissionDomainService per, IOperationServices ope, 
         IResourceDomainService res, IMapper mapper)
     {
         _per = per;
         _ope = ope;
         _res = res;
         _mapper = mapper;
     }

     /// <summary>
     /// 获取所有操作权限
     /// </summary>
     /// <returns></returns>
     /// <exception cref="NotImplementedException"></exception>
     public async Task<ReturnResult<List<Operation>>> GetAllOperation()
    {
        var opeList = await _ope.GetAllOperation();
        return ReturnResult<List<Operation>>.Success(opeList.Data);
    }
    /// <summary>
    /// 添加操作权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<OperCreateInfoDto>> AddOperation(OperCreateInfoDto input)
    {
        if(string.IsNullOrEmpty(input.poweName)){
            return ReturnResult<OperCreateInfoDto>.Error("操作名称不能为空");
        }
        if(_ope.GetOperationByName(input.poweName) != null){
            return ReturnResult<OperCreateInfoDto>.Error("该操作已存在");
        }
        
        var opeDto = _mapper.Map<OperCreateInfoDto,Operation>(input);
        await _ope.CreateOperation(opeDto);
        return ReturnResult<OperCreateInfoDto>.Success(input);
    }

    /// <summary>
    /// 删除操作权限
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Operation>> DeleteOperation(Guid id)
    {
        var operation = await _ope.DeleteOperation(id);
        if(! operation.IsSuccess){
            return ReturnResult<Operation>.Error("该权限删除失败");
        }
        return ReturnResult<Operation>.Success(operation.Data);
    }

    /// <summary>
    /// 修改操作权限
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ReturnResult<Operation>> UpdateOperation(Guid id, OperUpdateInfoDto input)
    {
        var op = _mapper.Map<OperUpdateInfoDto,Operation>(input);
        var operation = await _ope.UpdateOperation(id,op);
        if(! operation.IsSuccess){
            return ReturnResult<Operation>.Error("修改失败");
        }
        var opDto = _mapper.Map<Operation>(operation.Data);
        return ReturnResult<Operation>.Success(opDto);
    }

    /// <summary>
    /// 获取所有权限
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<List<Permission>>> GetAllPermission()
    {
        var perList = await _per.GetAllPermission();
        return ReturnResult<List<Permission>>.Success(perList.Data);
    }
    /// <summary>
    /// 添加权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<PerCreateInfoDto>> AddPermission(PerCreateInfoDto input)
    {
        if(string.IsNullOrEmpty(input.PermissionName)){
            return ReturnResult<PerCreateInfoDto>.Error("权限名称不能为空");
        }
        if(_per.GetPermissionByName(input.PermissionName) != null){
            return ReturnResult<PerCreateInfoDto>.Error("该权限已存在");
        }
        var perDto = _mapper.Map<PerCreateInfoDto,Permission>(input);
        await _per.AddPermission(perDto);
        return ReturnResult<PerCreateInfoDto>.Success(input);
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Permission>> DeletePermission(Guid id)
    {
       var per = await _per.RemovePermission(id);
       if(!per.IsSuccess){
          return ReturnResult<Permission>.Error("该权限删除失败");
       }
       return ReturnResult<Permission>.Success(per.Data);
    }

    /// <summary>
    /// 修改权限
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ReturnResult<Permission>> UpdatePermission(Guid id, PerUpdateInfoDto input)
    {
        var per = _mapper.Map<PerUpdateInfoDto,Permission>(input);
        var perUpdate = await _per.UpdatePermission(id,per);
        if(!perUpdate.IsSuccess){
            return ReturnResult<Permission>.Error("修改权限失败");
        }
        var perDto = _mapper.Map<Permission>(perUpdate.Data);
        return ReturnResult<Permission>.Success(perDto);
    }

    /// <summary>
    /// 获取所有资源权限
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<List<Resource>>> GetAllResource()
    {
        var resList = await _res.GetAllResource();
        return ReturnResult<List<Resource>>.Success(resList.Data);
    }
    /// <summary>
    /// 创建资源权限
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<ResCreateInfoDto>> AddResource(ResCreateInfoDto input)
    {
       if(string.IsNullOrEmpty(input.ResourceName)){
        return ReturnResult<ResCreateInfoDto>.Error("资源名称不能为空");
       }
       if(_res.GetResourceByName(input.ResourceName) != null){
        return ReturnResult<ResCreateInfoDto>.Error("资源名称重复");
       }
       
        var resDto = _mapper.Map<ResCreateInfoDto,Resource>(input);
        await _res.AddResource(resDto);
        return ReturnResult<ResCreateInfoDto>.Success(input);
    }
    /// <summary>
    /// 删除资源权限
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Resource>> DeleteResource(Guid id)
    {
       var res = await _res.RemoveResource(id);
       if(!res.IsSuccess){
          return ReturnResult<Resource>.Error("该权限删除失败");
       }
       return ReturnResult<Resource>.Success(res.Data);
    }

    
    public async Task<ReturnResult<Resource>> UpdateResource(Guid id, ResUpdateInfoDto input)
    {
        var res = _mapper.Map<ResUpdateInfoDto,Resource>(input);
        var resUpdate = await _res.UpdateResource(id,res);
        if(!resUpdate.IsSuccess){
            return ReturnResult<Resource>.Error("该权限更新失败");
        }
        var resDto = _mapper.Map<Resource>(resUpdate.Data);
        return ReturnResult<Resource>.Success(resDto);
    }
}