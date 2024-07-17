using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppUserConfiguration:BaseEntityConfiguration<AppUser>
{
    public override void Configure(EntityTypeBuilder<AppUser> builder)
    {
      // 调用基类的配置方法，以确保基础配置得到应用
      base.Configure(builder);
      // 指定表名
      builder.ToTable("app_user");
      // 每个实体配置独有的属性,顺序从3开始
      builder.Property(p => p.UserName)
        .HasColumnName("username")
        .HasComment("用户名")
        .HasColumnOrder(3);

      builder.Property(p => p.Password)
        .HasColumnName("password")
        .HasComment("密码")
        .HasColumnOrder(4);

      builder.Property(p => p.Salt)
        .HasColumnName("salt")
        .HasComment("密码")
        .HasColumnOrder(5);

      builder.Property(p => p.NickName)
        .HasColumnName("nickname")
        .HasComment("昵称")
        .HasColumnOrder(6);

      builder.Property(p => p.Avatar)
        .HasColumnName("avatar")
        .HasComment("头像")
        .HasColumnOrder(7);

      builder.Property(p => p.Tel)
        .HasColumnName("telephone")
        .HasComment("手机号")
        .HasColumnOrder(8);

      builder.Property(p => p.Weixin)
        .HasColumnName("weixin")
        .HasComment("微信")
        .HasColumnOrder(9);

      builder.Property(p => p.QQ)
        .HasColumnName("qq")
        .HasComment("QQ")
        .HasColumnOrder(10);
    }
}