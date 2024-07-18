namespace Admin2024.Api;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigureWebHostBuilder(args).Build().Run();
    }
    public static IHostBuilder ConfigureWebHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
            webBuilder.UseStartup<Startup>();
        });
    }
}