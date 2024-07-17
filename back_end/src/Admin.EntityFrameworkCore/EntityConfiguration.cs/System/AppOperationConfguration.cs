using Admin.Domain.Entity.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
public class AppOperationConfiguration:BaseEntityConfiguration<AppOperation>
{
    public override void Configure(EntityTypeBuilder<AppOperation> builder)
    {
        base.Configure(builder);
        // 表名
        builder.ToTable("app_operation");
        // 每个实体只要配置独有的属性，公共属性已经统一配置，顺序从3开始
        builder.Property(p => p.OperationName)
          .HasColumnName("operation_name")
          .HasComment("操作名称")
          .HasColumnOrder(3);

        builder.Property(p => p.Descript)
          .HasColumnName("description")
          .HasComment("描述，可空")
          .IsRequired(false)
          .HasColumnOrder(4); 
    }
}