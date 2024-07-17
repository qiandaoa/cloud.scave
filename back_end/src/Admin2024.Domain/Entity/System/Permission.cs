namespace Admin2024.Domain.System;

public class Permission : BaseEntity
{
    public string PermissionName { get; set; } = null!;
    public Guid ResourceId { get; set; }
    public Guid OperationId { get; set; }
}