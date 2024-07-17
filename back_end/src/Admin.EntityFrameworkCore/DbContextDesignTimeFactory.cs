// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace Admin.EntityFrameworkCore;
// // Entity Framework Core的设计时工厂类，用于在开发环境中生成DbContext实例
// public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<AdminDbContext>
// {
//     public AdminDbContext CreateDbContext(string[] args)
//     {
//         // 创建了 DbContextOptionsBuilder<AdminDbContext> 实例 optionsBuilder
//         // 用于构建AdminDbConext的配置选项
//         DbContextOptionsBuilder<AdminDbContext> optionsBuilder = new DbContextOptionsBuilder<AdminDbContext>();
//         optionsBuilder.UseNpgsql("server=0929zs.top;port=5929;database=admin_demo;uid=postgres;pwd=HXFlll091023*");
//         // 通过 optionsBuilder.Options 创建了 AdminDbContext 的实例，并将其返回
//         return new AdminDbContext(optionsBuilder.Options);
//     }
// }