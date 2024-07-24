using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using Microsoft.AspNetCore.Mvc;


namespace Admin2024.Api.Controller;
[ApiController]
[Route("api/[controller]")]
public class OperationController:ControllerBase
{ 
    private readonly IPermissionAppServices permission;
    public OperationController(IPermissionAppServices _permission)
    {
         this.permission = _permission;
    }
   [HttpPost("addOp")]
   public async Task<IActionResult> CreateOP([FromBody]CreateOPDto createOPDto)
   {
        var lastVal=await permission.CreateOP(createOPDto);
        return Ok(lastVal);
   }

   [HttpPut("updateOp")]
   public async Task<IActionResult>  UpdateOP([FromBody]UpdateOPDto updateOPDto)
   {
        var lastVal=await permission.UpdateOP(updateOPDto);
        return Ok(lastVal);
   }

   [HttpPost("deleteOp")]
   public async Task<IActionResult> DeleteOP([FromBody]DeleteOPDto deleteOPDto)
   {
       var lastVal=await permission.DeleteOP(deleteOPDto);
        return Ok(lastVal);
   }
   
   [HttpPost("pagingOp")]
   public async Task<ReturnResult<List<Operation>>> PagingOP([FromBody]PagingOPDto pagingOPDto)
   {
       var lastVal= await permission.PagingOP(pagingOPDto);
       return lastVal;
   }

   [HttpPost("findkey")]
    public async Task<ReturnResult<List<Operation>>>  FindkeyOP([FromBody]FindOPDto findOPDto)
   {
       var lastVal= await permission.FindkeyOP(findOPDto);
       return lastVal;
   }
}