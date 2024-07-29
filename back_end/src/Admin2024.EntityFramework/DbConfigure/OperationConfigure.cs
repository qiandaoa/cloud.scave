using Admin2024.Domain.System;
using Admin2024.EntityFramework.DbConfigure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public class OperationConfigure : BaseEntityConfigure<Operation>
{
    public override void Configure(EntityTypeBuilder<Operation> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.OperationName).HasColumnName("operation_name");

        builder.Property(e => e.Description).HasColumnName("description");
    }
}