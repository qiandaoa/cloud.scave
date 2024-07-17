using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppUserRoleConfiguration : BaseEntityConfiguration<AppUserRole>
{
   public override void Configure(EntityTypeBuilder<AppUserRole> builder)
   {
      base.Configure(builder);
      // 表名
      builder.ToTable("app_user_role");

      
      builder.Property(p => p.AppUserId)
      .HasColumnName("app_user_id")
      .HasComment("用户Id")
      .HasColumnOrder(3);

      builder.Property(p => p.AppRoleId)
      .HasColumnName("app_role_id")
      .HasComment("角色Id")
      .HasColumnOrder(4); 
   }
}