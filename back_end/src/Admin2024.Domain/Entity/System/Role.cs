namespace Admin2024.Domain.System;

public class Role : BaseEntity
{
    public List<Permission> _rolePermission { get; set; } = new List<Permission>();
    public string RoleName { get; set; } = null!;
    public Role()
    {

    }
    public Role(string roleName)
    {
        this.RoleName = roleName;
    }
    public void AllocatePermission(Permission permission)
    {
        _rolePermission.Add(permission);
    }
    public void RemovePermission(Permission permission)
    {
        _rolePermission.Remove(permission);
    }
    public bool HasPermission(Operation operation, Resource resource)
    {
        var entity = _rolePermission.FirstOrDefault(e => e.OperationId == operation.Id && e.ResourceId == resource.Id);
        return entity != null;
    }
}