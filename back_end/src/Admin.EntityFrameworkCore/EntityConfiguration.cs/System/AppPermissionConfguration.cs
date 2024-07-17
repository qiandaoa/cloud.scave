using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppPermissionConfiguration:BaseEntityConfiguration<AppPermission>
{
    public override void Configure(EntityTypeBuilder<AppPermission> builder)
    {
        base.Configure(builder);

        // 表名
        builder.ToTable("app_permission");

        builder.Property(p => p.AppResourceId)
          .HasColumnName("app_resource_id")
          .HasComment("资源Id")
          .HasColumnOrder(3);

        builder.Property(p => p.AppOperationId)
          .HasColumnName("app_operation_id")
          .HasComment("操作Id")
          .HasColumnOrder(4);
    }
}
