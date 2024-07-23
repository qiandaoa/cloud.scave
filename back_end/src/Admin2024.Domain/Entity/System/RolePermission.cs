namespace Admin2024.Domain.System;

public class RolePermission : BaseEntity
{
    public RolePermission(Guid roleId, Guid permissionId)
    {
        RoleId = roleId;
        PermissionId = permissionId;
    }


    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
}