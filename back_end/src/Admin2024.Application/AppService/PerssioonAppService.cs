using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.System;
using Admin2024.Instructions;

public class PermissionServices : IPermissionAppServices
{
     private readonly IOperationServices operationServices;
     public PermissionServices(IOperationServices _operationServices)
     {
         this.operationServices = _operationServices;
     }

    public async Task<ReturnResult<string>> CreateOP(CreateOPDto createOPDto)
    {
        var getval=await operationServices.CreateOperation(createOPDto.poweName,createOPDto.Description,createOPDto.CreateUse);
        return ReturnResult<string>.Success(getval.Message);
    }

    public  async Task<ReturnResult<string>> DeleteOP(DeleteOPDto deleteOPDto)
    {
        var getval=await operationServices.DeleteOperation(deleteOPDto.DeleteItem);
        return ReturnResult<string>.Success(getval.Message);
    }

    public async Task<ReturnResult<List<Operation>>> FindkeyOP(FindOPDto findOPDto)
    {
        var getval=await operationServices.FindOperation(findOPDto.keyword,findOPDto.PageNumber,findOPDto.PageSize);
        return getval;
    }

    public async Task<ReturnResult<List<Operation>>> PagingOP(PagingOPDto pagingOPDto)
    {
        var getval=await operationServices.PagingOperation(pagingOPDto.PageNumber,pagingOPDto.PageSize);
        return getval;
    }

    public async Task<ReturnResult<string>> UpdateOP(UpdateOPDto updateOPDto)
    {
       var getval=await operationServices.UpdateOperation(updateOPDto.poweName,updateOPDto.Description,updateOPDto.CreateUse,updateOPDto.UpdateOP);
        return ReturnResult<string>.Success(getval.Message);
    }
}