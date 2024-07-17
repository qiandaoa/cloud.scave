using Admin.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.EntityFrameworkCore.EntityConfiguration;
public abstract class BaseEntityConfiguration<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(p => p.Id)
          .HasColumnName("id")
          .HasComment("主键")
          .HasColumnOrder(1);

        builder.Property(p => p.BaseCode)
          .HasColumnName("base_code")
          .HasComment("编号，可空")
          .HasColumnOrder(2);

        builder.Property(p => p.IsActived)
          .HasColumnName("is_actived")
          .HasComment("是否启用，默认是")
          .HasDefaultValue(true)
          .HasColumnOrder(993);

        builder.Property(p => p.IsDeleted)
          .HasColumnName("is_deleted")
          .HasComment("是否删除，默认否")
          .HasDefaultValue(false)
          .HasColumnOrder(994);

        builder.Property(p => p.CreatedAt)
          .HasColumnName("create_at")
          .HasComment("创建时间，默认服务器当前时间")
          .HasDefaultValueSql("NOW()")  // 在pg数据库中获取当前时间用now()；在server数据库中用的是GETDATE()
          .HasColumnOrder(995);

        builder.Property(p => p.UpdatedAt)
          .HasColumnName("updated_at")
          .HasComment("更新时间，默认和创建时间相同")
          .HasDefaultValueSql("NOW()")
          .HasColumnOrder(996);

        builder.Property(p => p.CreatedBy)
          .HasColumnName("created_by")
          .HasComment("创建人Id，可空")
          .HasColumnOrder(997);
  
        builder.Property(p => p.UpdatedBy)
          .HasColumnName("updated_by")
          .HasComment("最后更新人Id，可空")
          .HasColumnOrder(998);
        
        builder.Property(p => p.DisplayOrder)
          .HasColumnName("display_order")
          .HasComment("展示的顺序，顺序大的排前面 默认为0")
          .HasColumnOrder(999);

        builder.Property(p => p.Remarks)
          .HasColumnName("remarks")
          .HasComment("备注")
          .HasColumnOrder(1000);
    }
}