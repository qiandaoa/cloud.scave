using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppRolePermissionConfiguration : BaseEntityConfiguration<AppRolePermission>
{
   public override void Configure(EntityTypeBuilder<AppRolePermission> builder)
   {
        base.Configure(builder);

        // 表名
        builder.ToTable("app_role_permission");

        builder.Property(p => p.AppRoleId)
          .HasColumnName("app_role_id")
          .HasComment("角色Id")
          .HasColumnOrder(3);

        builder.Property(p => p.AppPermissionId)
          .HasColumnName("app_permission_id")
          .HasComment("权限Id")
          .HasColumnOrder(4); 
   }
}