using Admin2024.Application.Contracts.UserApplication.Dto;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Admin2024.Api.Controller;
[ApiController]
[Route("/api/[controller]")]
public class AvatarController : ControllerBase
{
  private readonly IRepository<User> _repo;
  private readonly IMapper _mapper;
  public AvatarController(IRepository<User> repo, IMapper mapper)
  {
    _repo = repo;
    _mapper = mapper;
  }
  /// <summary>
  /// 更新头像和上传头像,可能还有bug，需要测试
  /// </summary>
  /// <returns></returns>
  [HttpPost("{id}")]
   public async Task<IActionResult> UploadFile(Guid id, IFormFile avatar)
   {
       if(avatar == null || avatar.Length == 0){
          return Ok("未提供文件");
       }
       var entity = await _repo.GetByIdAsync(id); // 找出对应的id的数据
       if (entity == null){
           return Ok("查找不到用户，修改失败");
       }
        var filePath = Path.Combine("wwwroot","Imgs", id.ToString()+avatar.FileName); //将文件路径经行拼接
        // 确保文件夹存在
        var directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        // 将文件内容写入到本地文件
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await avatar.CopyToAsync(stream); // 将上传的文件内容复制到文件流
        }

        var Avatarentity = new AvatarDto()
        {
            Avatar = Path.Combine("Imgs", id.ToString() + avatar.FileName)
        };

        _mapper.Map(Avatarentity, entity); // 映射
        await _repo.UpdateAsync(entity); // 更新数据
        return Ok(new { message = "头像上传成功", id });
   }

   /// <summary>
   /// 获取用户头像。上传git时,请将wwwroot下的imgs一起上传。图片访问地址https://localhost:63759/+图片名称
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
   [HttpGet("{id}")]
   public async Task<IActionResult> GetAvatar(Guid id)
   {
       var entity =await _repo.GetByIdAsync(id);
       return Ok("http://localhost:63760/" + entity.Avatar);
   }
}
