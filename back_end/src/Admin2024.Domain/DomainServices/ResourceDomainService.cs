using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
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
}