using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppRoleConfiguration : BaseEntityConfiguration<AppRole>
{
   public override void Configure(EntityTypeBuilder<AppRole> builder)
   {
        base.Configure(builder);

        // 表名
        builder.ToTable("app_role");

        builder.Property(p => p.RoleName)
          .HasColumnName("role_name")
          .HasComment("角色名称")
          .HasColumnOrder(3);
  
        builder.Property(p => p.Description)
          .HasColumnName("description")
          .HasComment("描述，可空")
          .IsRequired(false)
          .HasColumnOrder(4); 
   }
}