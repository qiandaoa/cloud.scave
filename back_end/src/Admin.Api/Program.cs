namespace Admin.Api;
public class Program
{
    public static void Main(string[] args)
    {
        CreateBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(builder=>{
                      builder.UseStartup<Startup>();
                   });
    }
}