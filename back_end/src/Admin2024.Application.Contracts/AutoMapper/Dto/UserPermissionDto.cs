namespace Admin2024.Application.Contracts;
public class UserPermissionDto
{
    public Guid UserId { get; set; }
    public string? Username { get; set; }
    public List<string>? RoleName { get; set; }
    public List<string>? PermissionName { get; set; }
}