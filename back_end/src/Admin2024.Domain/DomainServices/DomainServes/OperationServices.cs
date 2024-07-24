using System.Text.RegularExpressions;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public class OperationServices:IOperationServices
{
    private readonly IRepository<Operation> repository;
    private readonly IToolRepository<Operation > toolRepository;
    private readonly IRepository<User> USerepository;
    public OperationServices(IRepository<Operation> _repository,IRepository<User> _USerepository,IToolRepository<Operation > _toolRepository)
    {
         this.repository = _repository;
         this.USerepository = _USerepository;
         toolRepository=_toolRepository;
        
    }
    public async  Task<ReturnResult<Operation>> CreateOperation(string poweName,string? Descriptions,Guid CreateUse)
    {
         //检测和限制名字（中文或英文可包含数字）
          bool isValid = Regex.IsMatch(poweName, @"^(?:[\u4e00-\u9fa5]+|[a-zA-Z]+|[\u4e00-\u9fa5]+[a-zA-Z]+|[\u4e00-\u9fa5]+[a-zA-Z]+[\u4e00-\u9fa5]+|[a-zA-Z]+[\u4e00-\u9fa5]+[a-zA-Z]+)([0-9]*)?$");
          if(!isValid||poweName.Length<=0||poweName.Length>100)
          { 
               
             return ReturnResult<Operation>.Error("文本格式不符合");
          }
         
         //操作名是否存在
         var getAll=await repository.GetAsync();
        
            bool exists = getAll.Any(item => item.OperationName == poweName);
        if(exists)
        {
               return ReturnResult<Operation>.Error("该权限操作名已经存在");
        }
         
         var justUse=await USerepository.GetAsync();
         bool justUseId=justUse.Any(item => item.Id == CreateUse);
         if(CreateUse==Guid.Empty)
         {
            return ReturnResult<Operation>.Error("该权限操作创建者的id不为空");
         }else if(justUseId)
         {
            return ReturnResult<Operation>.Error("该权限操作创建者的id不存在");
         }


        
         //添加(在此之前可以继续对描述进行判断)
         var newOperation=new Operation{
             OperationName=poweName,
            Description=Descriptions,
            CreateAt=DateTime.Now,
            CreateBy=CreateUse
         };
         
         var findVal=await repository.AddAsync(newOperation);
         return ReturnResult<Operation>.Success(findVal);

    }


    public async Task<ReturnResult<Operation>> UpdateOperation(string poweName,string? Descriptions,Guid CreateUse,Guid UpdateOP)
    { 
        

         //修改对象的判断
         if(UpdateOP==Guid.Empty)
         {
            return ReturnResult<Operation>.Error("该权限操作修改对象的id不为空");
         }
         var justOP=await repository.GetByIdAsync(UpdateOP);
         if(justOP==null)
         {
            return ReturnResult<Operation>.Error("该权限操作修改目标的id对象不存在");
         }

         //修改人id是存在
        var justUse=await USerepository.GetAsync();
         bool justUseId=justUse.Any(item => item.Id == CreateUse);
         if(CreateUse==Guid.Empty)
         {
            return ReturnResult<Operation>.Error("该权限操作修改者的id不为空");
         }else if(justUseId)
         {
            return ReturnResult<Operation>.Error("该权限操作修改者的id对象不存在");
         }

        justOP.OperationName=poweName;
        justOP.Description=Descriptions;
        justOP.UpdateAt=DateTime.Now;
        justOP.UpdateBy=CreateUse;
       
       //进行修改
        var findVal=await repository.UpdateAsync(justOP);
        if(findVal!=null)
        {
             return ReturnResult<Operation>.Success(findVal);
        }
         
         return  ReturnResult<Operation>.Error("400,后端修改失败");

       


    }

    public async Task<ReturnResult<Operation>> DeleteOperation(Guid DeleteItem)
    {
        if(DeleteItem==Guid.Empty)
        {
             return  ReturnResult<Operation>.Error("删除目标id不为空");
        }
        var JustExite=await repository.GetByIdAsync(DeleteItem);
        if(JustExite==null)
        {
             return  ReturnResult<Operation>.Error("删除目标不存在");
        }
        JustExite.IsDeleted=true;
        var FindVal=await repository.UpdateAsync(JustExite);

        if(FindVal!=null)
        {
             return ReturnResult<Operation>.Success(FindVal);
        }
         
         return  ReturnResult<Operation>.Error("400,后端删除失败");
    }

    //全部分页查询
    public async   Task<ReturnResult<List<Operation>>>  PagingOperation(int? PageNumber,int? PageSize)
    { 
        var getAll = await repository.GetAsync();
        var PagingVal=toolRepository.PagingAny(getAll,PageNumber,PageSize);
         if(PagingVal==null)
         {
              return ReturnResult<List<Operation>>.Error("操作名分页查询失败");
         }
         return ReturnResult<List<Operation>>.Success(PagingVal);
        
    }
     //关键字查询
          public async Task<ReturnResult<List<Operation>>> FindOperation(string keyword, int? PageNumber, int? PageSize)
          {
          if (keyword == null)
          {
               return ReturnResult<List<Operation>>.Error("搜索关键字不为空");
          }

          var findAll = await repository.GetAsync();
          if (findAll == null)
          {
               return ReturnResult<List<Operation>>.Error("搜索关键字失败");
          }

          if (!string.IsNullOrEmpty(keyword))
          {
               findAll = findAll.Where(e => 
               //进行搜索目标
               (!string.IsNullOrEmpty(e.OperationName) && e.OperationName.Contains(keyword)) || 
               (!string.IsNullOrEmpty(e.Description) && e.Description.Contains(keyword))
               ).ToList();
          }

          var PagingVal = toolRepository.PagingAny(findAll, PageNumber, PageSize);
          if (PagingVal == null)
          {
               return ReturnResult<List<Operation>>.Error("查询完成，分页失败");
          }

          return ReturnResult<List<Operation>>.Success(PagingVal);
          }
}