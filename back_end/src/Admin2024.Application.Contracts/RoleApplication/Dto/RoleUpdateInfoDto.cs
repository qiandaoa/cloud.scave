using Admin2024.Domain;

namespace Admin2024.Application.Contracts.RoleApplication.Dto;
public class RoleUpdateInfoDto:BaseEntity
{
  public string RoleName { get; set; } = null!;

}