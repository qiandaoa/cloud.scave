using Admin2024.Application.Contracts.PermissionApplication.Dto;
using Admin2024.Application.Contracts.PermissionApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.Helps;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc;

namespace Admin2024.Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class permissionController : ControllerBase
{
  private readonly IPermissionAppService _per;
  public permissionController(IPermissionAppService per)
  {
      _per = per;
  }

// ----------------------------------------权限--------------------------------------------------
  /// <summary>
  /// 获取全部权限
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ReturnResult<List<Permission>>> GetAllPermission([FromQuery]BaseParameters baseParameters)
  {
      var perList = await _per.GetAllPermission();
      var keywords = baseParameters.keywords;
      if(!string.IsNullOrEmpty(keywords)){
        var filePer = perList.Data.Where(p => p.PermissionName.Contains(keywords)).ToList();
        return ReturnResult<List<Permission>>.Success(filePer);
      }
      return ReturnResult<List<Permission>>.Success(perList.Data);
  }

  /// <summary>
  /// 连表查询权限
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet("api/perList")]
  public IActionResult GetPerList([FromQuery] BaseParameters baseParameters)
  {
    var perList = _per.GetPermissionList();
    var keywords = baseParameters.keywords;
        if(!string.IsNullOrEmpty(keywords)){
            var filer = perList.FirstOrDefault(p => 
                p.ResourceName.Contains(keywords) ||
                p.OperationName.Contains(keywords)||
                p.PermissionDes.Contains(keywords));
            return Ok(filer);
        }
    return Ok(perList);
  }
  /// <summary>
  /// 新增权限
  /// </summary>
  /// <param name="perCreateInfoDto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<ReturnResult<PerCreateInfoDto>> AddPermission(PerCreateInfoDto perCreateInfoDto)
  {
    return await _per.AddPermission(perCreateInfoDto);
  }

  /// <summary>
  /// 移除权限
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("{id}")]
  public async Task<ReturnResult<Permission>> DeletePermission(Guid id)
  {
    return await _per.DeletePermission(id);
  }

  /// <summary>
  /// 修改权限
  /// </summary>
  /// <param name="id"></param>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPut("{id}")]
  public async Task<ReturnResult<Permission>> UpdatePermission(Guid id, PerUpdateInfoDto input)
  {
    return await _per.UpdatePermission(id, input);
  }

// ----------------------------------------资源--------------------------------------------------
  /// <summary>
  /// 获取全部资源
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet("api/resource")]
  public async Task<ReturnResult<List<Resource>>> GetAllResource([FromQuery]BaseParameters baseParameters)
  {
    var resList = await _per.GetAllResource();
    var keywords = baseParameters.keywords;
    if (!string.IsNullOrEmpty(keywords))
    {
      var fileRes = resList.Data.Where(r => r.ResourceName.Contains(keywords)).ToList();
      return ReturnResult<List<Resource>>.Success(fileRes);
    }
    return ReturnResult<List<Resource>>.Success(resList.Data);
  }
  /// <summary>
  /// 创建资源权限
  /// </summary>
  /// <param name="resCreateInfoDto"></param>
  /// <returns></returns>
  [HttpPost("/api/resource")]
  public async Task<ReturnResult<ResCreateInfoDto>> AddResource(ResCreateInfoDto resCreateInfoDto)
  {
    return await _per.AddResource(resCreateInfoDto);
  }

  /// <summary>
  /// 删除资源权限
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("/api/resource/{id}")]
  public async Task<ReturnResult<Resource>> DeleteResource(Guid id)
  {
    return await _per.DeleteResource(id);
  }

  /// <summary>
  /// 修改资源权限
  /// </summary>
  /// <param name="id"></param>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPut("/api/resource/{id}")]
  public async Task<ReturnResult<Resource>> UpdateResource(Guid id, ResUpdateInfoDto input)
  {
    return await _per.UpdateResource(id, input);
  }

// ----------------------------------------操作--------------------------------------------------
  /// <summary>
  /// 获取全部操作
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet("api/operation")]
  public async Task<ReturnResult<List<Operation>>> GetAllOperation([FromQuery]BaseParameters baseParameters)
  {
    var operationList = await _per.GetAllOperation();
    var keywords = baseParameters.keywords;
    if(!string.IsNullOrEmpty(keywords)){
      var fileOp = operationList.Data.Where(o => o.OperationName.Contains(keywords)).ToList();
      return ReturnResult<List<Operation>>.Success(fileOp);
    }
    return ReturnResult<List<Operation>>.Success(operationList.Data);
  }
  /// <summary>
  /// 添加操作权限
  /// </summary>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPost("api/operation")]
  public async Task<ReturnResult<OperCreateInfoDto>> AddOperation(OperCreateInfoDto input)
  {
    return await _per.AddOperation(input);
  }

  /// <summary>
  /// 删除操作权限
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("api/operation/{id}")]
  public async Task<ReturnResult<Operation>> DeleteOperation(Guid id)
  {
    return await _per.DeleteOperation(id);
  }

  /// <summary>
  /// 修改操作权限
  /// </summary>
  /// <param name="id"></param>
  /// <param name="input"></param>
  /// <returns></returns>
  [HttpPut("api/operation/{id}")]
  public async Task<ReturnResult<Operation>> UpdateOperation(Guid id, OperUpdateInfoDto input)
  {
    return await _per.UpdateOperation(id, input);
  }

}