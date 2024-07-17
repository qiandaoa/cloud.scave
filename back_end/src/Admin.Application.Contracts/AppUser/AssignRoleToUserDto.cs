namespace Admin.Application.Contracts.AppUser;
public class AssigmRoleToUserDto
{
    public Guid AppUserId { get; set;} 
    public Guid AppRoleId { get; set;}
}