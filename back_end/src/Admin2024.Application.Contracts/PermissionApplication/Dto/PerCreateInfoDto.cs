namespace Admin2024.Application.Contracts.PermissionApplication.Dto;
public class PerCreateInfoDto
{
  public string PermissionName { get; set; } = null!;
  public Guid ResourceId { get; set; }
  public Guid OperationId { get; set; }
}