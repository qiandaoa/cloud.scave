using System.Text.RegularExpressions;
using Admin2024.Domain.DomainServices.Interface;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices.Services;
public class OperationServices : IOperationServices
{
     private IRepository<Operation> _ope;
     public OperationServices(IRepository<Operation> ope)
     {
          _ope = ope;
     }
 
    // 创建操作权限
    public async Task<ReturnResult<Operation>> CreateOperation(Operation operation)
    {
        var op = _ope.Table.FirstOrDefault(o => o.OperationName == operation.OperationName);
        if(op != null){
          return ReturnResult<Operation>.Error("操作权限已存在");
        }
        var res = await _ope.AddAsync(operation);
        return ReturnResult<Operation>.Success(res);
    }

    // 移除操作
    public async Task<ReturnResult<Operation>> DeleteOperation(Guid opId)
    {
        var op = await _ope.DeleteAsync(opId);
        if(op == null){
          return ReturnResult<Operation>.Error("操作不存在");
        }
        return ReturnResult<Operation>.Success(op);
    }

    // 获取所有操作
    public async Task<ReturnResult<List<Operation>>> GetAllOperation()
    {
        var operationList = await _ope.GetAsync();
        if(operationList == null){
            return ReturnResult<List<Operation>>.Error("操作列表为空");
        }
        return ReturnResult<List<Operation>>.Success(operationList);
    }

    // 根据操作名称查找
    public Operation? GetOperationByName(string OperationName)
    {
        var op = _ope.Table.FirstOrDefault(o => o.OperationName == OperationName);
        return op;
    }

    // 修改操作

    public async Task<ReturnResult<Operation>> UpdateOperation(Guid id, Operation operation)
    {
        var opInfo = await _ope.GetByIdAsync(id);
        if(opInfo == null){
            return ReturnResult<Operation>.Error("操作不存在");
        }
        opInfo.OperationName = operation.OperationName;
        opInfo.Description = operation.Description;
        await _ope.UpdateAsync(opInfo);
        return ReturnResult<Operation>.Success(opInfo);
    }
}