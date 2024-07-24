namespace Admin2024.Application.Contracts.PermissionApplication.Dto;
public class PermissionCreateInfoDto
{
  public Guid ResourceId { get; set; }
  public Guid OperationId { get; set; }
}