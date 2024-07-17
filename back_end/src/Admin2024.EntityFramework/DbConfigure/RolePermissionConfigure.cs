using Admin2024.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public class RolePermissionConfigure : BaseEntityConfigure<RolePermission>
{
    public override void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.RoleId).HasColumnName("role_id");

        builder.Property(e => e.PermissionId).HasColumnName("permission_id");
    }
}