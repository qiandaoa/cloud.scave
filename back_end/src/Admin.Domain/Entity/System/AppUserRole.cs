namespace Admin.Domain.Entity.System;
public class AppUserRole:BaseEntity
{
  public Guid AppUserId { get; set; }
  public Guid AppRoleId { get; set;}
}