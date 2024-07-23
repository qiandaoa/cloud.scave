using Admin2024.Application.Contracts.RoleApplication.Dto;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.Helps;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin2024.Api;
[ApiController]
[Route("/api/[controller]")]
public class RoleController : ControllerBase
{
  private readonly IRepository<Role> _repRole;
  private readonly IMapper _mapper;
  public RoleController(IRepository<Role> repRole,IMapper mapper)
  {
    _repRole = repRole;
    _mapper = mapper;
  }

  /// <summary>
  /// 获取全部角色 keywords表示关键字 pageindex表示页数 pagesize表示每页的内容数量
  /// </summary>
  /// <param name="baseParameters"></param>
  /// <returns></returns>
  [HttpGet]
  public ActionResult<List<Role>> GetAllRole([FromQuery]BaseParameters baseParameters)
  {
    var roles = _repRole.Table;
    var keywords = baseParameters.keywords;

    // 进行角色名称关键字搜索
    if(!string.IsNullOrEmpty(keywords)){
      roles = roles.Where(x => 
         x.RoleName.Contains(keywords)
      );
    }
    return Ok(roles);
  }

  /// <summary>
  /// 获取指定id的角色
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet("{id}")]
  public async Task<ActionResult<Role>> GetRoleById(Guid id)
  {
    var role = await _repRole.GetByIdAsync(id);
    if(role == null){
      return NotFound();
    }
    return Ok(role);
  }

  /// <summary>
  /// 添加角色
  /// </summary>
  /// <param name="roleCreateInfoDto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> PostRole(RoleCreateInfoDto roleCreateInfoDto)
  {
    var IsExist = await _repRole.Table.FirstOrDefaultAsync(x => x.RoleName == roleCreateInfoDto.RoleName);
    if(IsExist != null){
      return Ok("该角色已存在，请勿重复添加");
    }
    var role = _mapper.Map<Role>(roleCreateInfoDto);
        role.IsDeleted = false;
    var newRole = await _repRole.AddAsync(role);
    if(newRole == null){
      return Ok("添加失败");
    }
    var roleDto = _mapper.Map<Role>(newRole);
    return Ok(roleDto);
  }

  /// <summary>
  /// 删除角色（软删除）
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRole(Guid id)
  {
    var role = await _repRole.GetByIdAsync(id);
    if(role == null){
      return NotFound();
    }
    await _repRole.DeleteAsync(id);
    return Ok(role);
  }

  /// <summary>
  /// 修改角色信息
  /// </summary>
  /// <param name="id"></param>
  /// <param name="roleUpdateInfoDto"></param>
  /// <returns></returns>
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateRole(Guid id, RoleUpdateInfoDto roleUpdateInfoDto)
  {
    var role = await _repRole.GetByIdAsync(id);
    if(role == null){
      return Ok("查找不到角色，修改失败");
    }
    _mapper.Map(roleUpdateInfoDto, role);
    var updateRole = await _repRole.UpdateAsync(role);
    if(updateRole == null){
      return Ok("修改失败");
    }
    var roleDto = _mapper.Map<Role>(role);
    return Ok(roleDto);
  }
}