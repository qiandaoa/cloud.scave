using Admin2024.Domain;

namespace Admin2024.Application.Contracts.RoleApplication.Dto;
public class RoleCreateInfoDto
{
  public string RoleName { get; set; } = null!;
  public string? Remark { get; set; }
}