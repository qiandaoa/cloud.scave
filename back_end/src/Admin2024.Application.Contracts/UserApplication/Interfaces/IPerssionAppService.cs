using Admin2024.Instructions;
using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.System;


namespace Admin2024.Application.Contracts.UserApplication.Interface;
public interface IPermissionAppServices
{
    //权限操作的添加
     Task<ReturnResult<string>> CreateOP(CreateOPDto createOPDto);

     //权限操作的修改
      Task<ReturnResult<string>> UpdateOP(UpdateOPDto updateOPDto);

     //权限操作的删除
     Task<ReturnResult<string>> DeleteOP(DeleteOPDto deleteOPDto);

     //权限操作分页查询
     Task<ReturnResult<List<Operation>>> PagingOP(PagingOPDto pagingOPDto);

     //关键字查询
      Task<ReturnResult<List<Operation>>> FindkeyOP(FindOPDto findOPDto);

}