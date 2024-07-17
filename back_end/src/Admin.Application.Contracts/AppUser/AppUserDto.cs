namespace Admin.Application.Contracts.AppUser;
public class AppUserDto
{
  public Guid Id { get; set; }
  public string UserName { get; set;} = null!;
}