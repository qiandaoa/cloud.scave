using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Interface;
public interface IOperationServices
{
     // 获取全部操作
     Task<ReturnResult<List<Operation>>> GetAllOperation();
     // 根据操作名称查找
     Operation? GetOperationByName(string operationName);
     // 创建操作权限
     Task<ReturnResult<Operation>> CreateOperation(Operation operation);
     // 修改操作权限
     Task<ReturnResult<Operation>> UpdateOperation(Guid id, Operation operation);
     // 删除操作权限
     Task<ReturnResult<Operation>> DeleteOperation(Guid opId);
     
}