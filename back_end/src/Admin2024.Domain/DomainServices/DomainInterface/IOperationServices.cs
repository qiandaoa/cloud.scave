using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IOperationServices
{
     Task<ReturnResult<Operation>> CreateOperation(string poweName,string? Descriptions,Guid CreateUse);
     Task<ReturnResult<Operation>> UpdateOperation(string poweName,string? Descriptions,Guid CreateUse,Guid UpdateOP);

     Task<ReturnResult<Operation>> DeleteOperation(Guid DeleteItem);
     //分页查询
     Task<ReturnResult<List<Operation>>> PagingOperation(int? PageNumber,int? PageSize);
     //关键字查询
       Task<ReturnResult<List<Operation>>>  FindOperation(string keyword,int? PageNumber, int? PageSize);
}