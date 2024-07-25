using Admin2024.Domain.System;
using Admin2024.EntityFramework.DbConfigure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public class ResourceConfigure : BaseEntityConfigure<Resource>
{
    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.ResourceName).HasColumnName("resource_name");

        builder.Property(e => e.Description).HasColumnName("description");
    }
}