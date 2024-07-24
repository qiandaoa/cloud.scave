using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Interface;
public interface IResourceDomainService
{
  // 获取所有资源
  Task<ReturnResult<List<Resource>>> GetAllResource();
  // 新建资源权限
  Task<ReturnResult<Resource>> AddResource(Resource resource);

  // 修改资源权限
  Task<ReturnResult<Resource>> UpdateResource(Guid id, Resource resource);

  // 移除资源权限
  Task<ReturnResult<Resource>> RemoveResource(Guid id);

  // 根据资源名称查找
  Resource? GetResourceByName(string resourceName);
}