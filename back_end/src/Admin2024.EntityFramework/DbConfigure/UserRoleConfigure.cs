using Admin2024.Domain.System;
using Microsoft.EntityFrameworkCore;

namespace Admin2024.EntityFramework.DbConfigure;

public class UserRoleConfigure : BaseEntityConfigure<UserRole>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.Property(e => e.RoleId).HasColumnName("role_id");
    }
}