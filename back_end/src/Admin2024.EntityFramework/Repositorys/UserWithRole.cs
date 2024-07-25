namespace Admin2024.EntityFramework.Repositories;
public class UserWithRole
{
  public Guid  Userld { get; set; }
  public Guid RoleId { get; set; }
  public string Username { get; set; }
  public string Nickname { get; set; }
  public string Avatar { get; set; }
  public string Email {get; set; }
  public string Telephone { get; set; }
  public string UseRemark { get; set; }
  public string RoleName { get; set; }
  public string RoleRemark { get; set; }
  
}