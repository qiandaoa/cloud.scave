namespace Admin.Application.Contracts.AppUser;
public class AssignUsertoRoleResultDto
{
  public Guid Id{ get; set; }
  public Guid AppUserId { get; set; }
  public Guid AppRoleId { get; set; }
}