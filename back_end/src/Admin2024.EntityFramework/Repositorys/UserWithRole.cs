using Microsoft.Net.Http.Headers;

namespace Admin2024.EntityFramework.Repositories;
public class UserWithRole
{
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid RoleId { get; set; }
  public string Username { get; set; }
  public string Nickname { get; set; }
  public string Avatar { get; set; }
  public string Email {get; set; }
  public string Telephone { get; set; }
  public string UseRemark { get; set; }
  public string RoleName { get; set; }
  public string RoleRemark { get; set; }
  public bool IsActived { get; set; }
  public bool IsDeleted {get;set;}
  public bool UserRoleIsDeleted {get; set; }
}