using Admin.Domain.Entity.System;
using Admin.EntityFrameworkCore.EntityConfiguration.Syetem;
using Microsoft.EntityFrameworkCore;

namespace Admin.EntityFrameworkCore;
public class AdminDbContext: DbContext
{
  public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
  {

  }
  // 定义表
  public DbSet<AppUser> AppUser { get; set; }
  public DbSet<AppRole> AppRole { get; set; }
  public DbSet<AppUserRole> AppUserRole{ get; set; }
  public DbSet<AppOperation> AppOperation{ get; set; }
  public DbSet<AppPermission> AppPermission { get; set; }
  public DbSet<AppResource> AppResource { get; set; }
  public DbSet<AppRolePermission> AppRolePermission { get; set; }

    // 配置实体
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppUserConfiguration).Assembly);
    }
}


//   protected override void OnModelCreating(ModelBuilder modelBuilder)
//   {
//     base.OnModelCreating(modelBuilder);
//     modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration.Syetem.AppUserConfiguration).Assembly);
//   }

//   #region 定义表
//   public DbSet<AppUser> AppUser{ get; set; }
//   public DbSet<AppRole> AppRole { get; set; }
//   public DbSet<AppUserRole> AppUserRole{ get; set; }
//   public DbSet<AppOperation> AppOperation{ get; set; }
//   public DbSet<AppPermission> AppPermission { get; set; }
//   public DbSet<AppResource> AppResource { get; set; }
//   public DbSet<AppRolePermission> AppRolePermission { get; set; }
//   #endregion
// }