using Admin2024.Domain;
using Admin2024.Domain.System;
using Admin2024.EntityFramework.DbConfigure;
using Microsoft.EntityFrameworkCore;

namespace Admin2024.EntityFramework;

public class AdminDbContext : DbContext
{
    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfigure).Assembly);

        modelBuilder.Entity<User>(entity => {
            var userId = Guid.NewGuid();
            entity.HasData(
                new User{
                Id = userId,
                Username = "Boss",
                Password = "abc123456",
                Salt = "aaaasssddd",
                Telephone = "12345678910",
                Email = "abc@123456.com",
                IsActived = true,
                IsDeleted = false,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                CreateBy = userId,
                UpdateBy = userId,
                Remark = "aaa"
            }
            );
        });
    }

    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity);

        entities.Where(item => item.State == EntityState.Added).ToList().ForEach(x => {
            var entity = (BaseEntity)x.Entity;

            entity.CreateAt = DateTime.UtcNow;
            entity.UpdateAt = DateTime.UtcNow;

            entity.CreateBy = entity.Id;
            entity.UpdateBy = entity.Id;
        });

        entities.Where(item => item.State == EntityState.Modified).ToList().ForEach(x => {
            var entity = (BaseEntity)x.Entity;
            entity.UpdateAt = DateTime.UtcNow;
        });

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity);

        entities.Where(item => item.State == EntityState.Added).ToList().ForEach(x => {
            var entity = (BaseEntity)x.Entity;

            entity.CreateAt = DateTime.UtcNow;
            entity.UpdateAt = DateTime.UtcNow;
        });

        entities.Where(item => item.State == EntityState.Modified).ToList().ForEach(x => {
            var entity = (BaseEntity)x.Entity;
            entity.UpdateAt = DateTime.UtcNow;
        });

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<Resource> Resource { get; set; }
    public DbSet<Operation> Operation { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
}