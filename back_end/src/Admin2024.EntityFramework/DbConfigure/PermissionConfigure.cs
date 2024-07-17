using Admin2024.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public class PermissionConfigure : BaseEntityConfigure<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.PermissionName).HasColumnName("permission_name");

        builder.Property(e => e.OperationId).HasColumnName("operation_id");

        builder.Property(e => e.ResourceId).HasColumnName("resource_id");
    }
}