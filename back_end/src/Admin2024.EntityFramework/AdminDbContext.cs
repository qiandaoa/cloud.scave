using System.Data.Common;
using Admin2024.Domain;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.DomainServices.Services;
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

        Guid superAdmin = Guid.NewGuid();
        Guid admin = Guid.NewGuid();
        Guid commonUser = Guid.NewGuid();
        modelBuilder.Entity<User>(entity =>
        {
            var salt = PasswordHelper.GenerateSalt();
            entity.HasData([
                new User
                {
                    Id = superAdmin,
                    Username = "admin",
                    Password = PasswordHelper.HashPassword("admin123456", salt),
                    Salt = salt,
                    NickName="超级管理员",
                    Telephone = "12345678910",
                    Email = "abc@123456.com",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    CreateBy = superAdmin,
                    UpdateBy = superAdmin,
                    Remark = "aaa"
                },
                new User
                {
                    Id = admin,
                    Username = "svip",
                    Password = PasswordHelper.HashPassword("svip123456", salt),
                    Salt = "aaaasssddd",
                    NickName="管理员",
                    Telephone = "12345678910",
                    Email = "abc@123456.com",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    CreateBy = admin,
                    UpdateBy = admin,
                    Remark = "aaa"
                },
                new User
                {
                    Id = commonUser,
                    Username = "001",
                    Password = PasswordHelper.HashPassword("123456", salt),
                    Salt = "aaaasssddd",
                    NickName="普通用户",
                    Telephone = "12345678910",
                    Email = "abc@123456.com",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    CreateBy = commonUser,
                    UpdateBy = commonUser,
                    Remark = "aaa"
                }
            ]);
        });

        Guid superAdminId = Guid.NewGuid();
        Guid adminId = Guid.NewGuid();
        Guid commonUserId = Guid.NewGuid();
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasData([
                new Role
                {
                    Id = superAdminId,
                    RoleName = "超级管理员",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                },
                new Role{
                    Id = adminId,
                    RoleName = "管理员",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                },
                new Role{
                    Id = commonUserId,
                    RoleName = "普通用户",
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                }
            ]);
        });


        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasData([
                new UserRole{
                    Id = Guid.NewGuid(),
                    UserId = superAdmin,
                    RoleId = superAdminId,
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                },
                new UserRole{
                    Id = Guid.NewGuid(),
                    UserId = admin,
                    RoleId = adminId,
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                },
                new UserRole{
                    Id = Guid.NewGuid(),
                    UserId = commonUser,
                    RoleId = commonUserId,
                    IsActived = true,
                    IsDeleted = false,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Remark = ""
                }
            ]);
        });
    }

    public override int SaveChanges()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity);

        entities.Where(item => item.State == EntityState.Added).ToList().ForEach(x =>
        {
            var entity = (BaseEntity)x.Entity;

            entity.CreateAt = DateTime.UtcNow;
            entity.UpdateAt = DateTime.UtcNow;

            entity.CreateBy = entity.Id;
            entity.UpdateBy = entity.Id;
        });

        entities.Where(item => item.State == EntityState.Modified).ToList().ForEach(x =>
        {
            var entity = (BaseEntity)x.Entity;
            entity.UpdateAt = DateTime.UtcNow;
        });

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity);

        entities.Where(item => item.State == EntityState.Added).ToList().ForEach(x =>
        {
            var entity = (BaseEntity)x.Entity;

            entity.CreateAt = DateTime.UtcNow;
            entity.UpdateAt = DateTime.UtcNow;
        });

        entities.Where(item => item.State == EntityState.Modified).ToList().ForEach(x =>
        {
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