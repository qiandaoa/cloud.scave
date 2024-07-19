using System.Reflection;
using System.Text;
using Admin2024.Api.Extension;
using Admin2024.Application.AppService;
using Admin2024.Application.Contracts.AutoMapper;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.ObjectValue;
using Admin2024.EntityFramework;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
namespace Admin2024.Api;
public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        // 注册要通过的反射创建的组件
        // 将整个服务程序集经行注入
        //var assemblysDomian = Assembly.Load("Admin2024.Domain"); // 这里注入的必须要是实现类 Load解决方案名称
        //builder.RegisterAssemblyTypes(assemblysDomian).AsImplementedInterfaces(); // 扫描整个程序集为提供所有其实现的接口
        //var assemblysApplication= Assembly.Load("Admin2024.Application"); 
        //builder.RegisterAssemblyTypes(assemblysApplication).AsImplementedInterfaces();
        //var assemblysEntityFramework = Assembly.Load("Admin2024.EntityFramework");
        //builder.RegisterAssemblyTypes(assemblysEntityFramework).AsImplementedInterfaces();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
            // Optional: Set the Swagger UI to the app's root URL
            // c.RoutePrefix = string.Empty;
        });
        app.UseRouting();
        app.UseCors("AllowOrigin");
        // app.UseAuthentication();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors("CorsTest");
        app.UseEndpoints(endPoints =>
        {
            endPoints.MapControllers();
        });
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCORS();
        services.AddAutoMapper(typeof(UserProfile));
        services.AddSwagger(_configuration);
        services.AddControllers();
        services.AddDbContext<AdminDbContext>(opt =>
        {
            opt.UseNpgsql(_configuration.GetConnectionString("pg"));
        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IAuthServices), typeof(AuthServices));
        services.AddScoped(typeof(IUserDomainService), typeof(UserDomainService));
        services.AddScoped(typeof(IUserAppService), typeof(UserAppService));
    }
}