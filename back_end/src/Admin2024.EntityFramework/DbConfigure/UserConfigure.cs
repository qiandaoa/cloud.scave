using Admin2024.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin2024.EntityFramework.DbConfigure;

public class UserConfigure : BaseEntityConfigure<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Username).HasColumnName("username");

        builder.Property(e => e.Password).HasColumnName("password");

        builder.Property(e => e.Salt).HasColumnName("salt");

        builder.Property(e => e.Telephone).HasColumnName("telephone");

        builder.Property(e => e.Email).HasColumnName("email");
    }
}