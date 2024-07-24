using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IUseRoleServices
{
     Task<ReturnResult<UserRole>> CreateUseRole(Guid useId,Guid roleId);

      Task<ReturnResult<UserRole>> DeleteUseRole(Guid useRoleId);

      //分页查询
      Task<ReturnResult<List<UserRole>>> PagingUserRole(int? PageNumber, int? PageSize);
}