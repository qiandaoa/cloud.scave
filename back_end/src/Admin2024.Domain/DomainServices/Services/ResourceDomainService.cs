using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Services;
public class ResourceDomainService : IResourceDomainService
{
    private readonly IRepository<Resource> _resourceRep;
    public ResourceDomainService(IRepository<Resource> resourceRep)
    {
        _resourceRep = resourceRep;
    }

    /// <summary>
    /// 新建资源权限
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Resource>> AddResource(Resource resource)
    {
        var resIsExis = _resourceRep.Table.FirstOrDefault(r => r.ResourceName == resource.ResourceName);
        if (resIsExis != null)
        {
            return ReturnResult<Resource>.Error("资源权限已存在");
        }
        var resCreate = await _resourceRep.AddAsync(resource);
        return ReturnResult<Resource>.Success(resCreate);
    }

    /// <summary>
    /// 获取所有资源
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<List<Resource>>> GetAllResource()
    {
        var resList = await _resourceRep.GetAsync();
        if(resList == null){
            return ReturnResult<List<Resource>>.Error("资源列表为空");
        }
        return ReturnResult<List<Resource>>.Success(resList);
    }

    /// <summary>
    /// 根据资源名称查找
    /// </summary>
    /// <param name="resourceName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Resource? GetResourceByName(string resourceName)
    {
        var res = _resourceRep.Table.FirstOrDefault(r => r.ResourceName == resourceName);
        return res;
    }

    /// <summary>
    /// 移除资源权限
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Resource>> RemoveResource(Guid id)
    {
        var res = await _resourceRep.DeleteAsync(id);
        if(res == null){
          return ReturnResult<Resource>.Error("资源权限不存在");
        }
        return ReturnResult<Resource>.Success(res);
    }

    /// <summary>
    /// 修改资源权限
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ReturnResult<Resource>> UpdateResource(Guid id, Resource resource)
    {
       var resInfo = await _resourceRep.GetByIdAsync(id);
       if (resInfo == null)
       {
           return ReturnResult<Resource>.Error("资源不存在");
       }
       resInfo.ResourceName = resource.ResourceName;
       resInfo.Description = resource.Description;
       await _resourceRep.UpdateAsync(resInfo);
       return ReturnResult<Resource>.Success(resInfo);
    }
}