using System.Data.SqlTypes;
using Admin2024.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public abstract class BaseEntityConfigure<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.IsActived).HasColumnName("is_actived").HasDefaultValue(true);

        builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);

        builder.Property(e => e.CreateAt).HasColumnName("create_at").HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.UpdateAt).HasColumnName("update_at").HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.CreateBy).HasColumnName("create_by");

        builder.Property(e => e.UpdateBy).HasColumnName("update_by");

        builder.Property(e => e.Remark).HasColumnName("remarks");
    }
}