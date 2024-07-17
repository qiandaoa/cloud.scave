using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppResourceConfiguration:BaseEntityConfiguration<AppResource>
{
    public override void Configure(EntityTypeBuilder<AppResource> builder)
    {
        base.Configure(builder);

        // 表名
        builder.ToTable("app_resource");

        builder.Property(p => p.ResourceName)
          .HasColumnName("resource_name")
          .HasComment("资源名称")
          .HasColumnOrder(3);

        builder.Property(p => p.Url)
          .HasColumnName("url")
          .HasComment("访问地址")
          .HasColumnOrder(4); 
    }
}