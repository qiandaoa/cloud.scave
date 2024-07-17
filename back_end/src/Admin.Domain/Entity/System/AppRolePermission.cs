namespace Admin.Domain.Entity.System;
public class AppRolePermission:BaseEntity
{
  
  public Guid AppRoleId { get; set; }
  public Guid AppPermissionId { get; set; }
 
}