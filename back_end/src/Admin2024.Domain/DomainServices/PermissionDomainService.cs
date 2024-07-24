using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public class PermissionDomainService : IPermissionDomainService
{
    private readonly IRepository<Permission> _perRep;
    public PermissionDomainService(IRepository<Permission> perRep)
    {
        _perRep = perRep;
    }
    public async Task<ReturnResult<Permission>> AddPermission(Permission permission)
    {
       var operIsExist = _perRep.Table.FirstOrDefault(p => p.OperationId == permission.OperationId);
       if(operIsExist != null){
         return ReturnResult<Permission>.Error("该权限已存在");
       }
       var perCreate = await _perRep.AddAsync(permission);
       return ReturnResult<Permission>.Success(perCreate);
    }

    public async Task<ReturnResult<Permission>> RemovePermission(Guid id)
    {
        var per = await _perRep.DeleteAsync(id);
        if(per == null){
            return ReturnResult<Permission>.Error("该权限不存在");
        }
        return ReturnResult<Permission>.Success(per);
    }
}