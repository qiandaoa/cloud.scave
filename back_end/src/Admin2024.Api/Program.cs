using Autofac.Extensions.DependencyInjection;

namespace Admin2024.Api;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigureWebHostBuilder(args).Build().Run();
    }
    public static IHostBuilder ConfigureWebHostBuilder(string[] args)
    {
        
        return Host.CreateDefaultBuilder(args) // 添加Autofac工厂服务
        .ConfigureWebHostDefaults(webBuilder => {
            webBuilder.UseUrls("http://localhost:63760");
            webBuilder.UseStartup<Startup>().UseWebRoot("wwwroot");
        });
    }
}