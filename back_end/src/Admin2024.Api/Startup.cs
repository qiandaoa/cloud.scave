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
        // ע��Ҫͨ���ķ��䴴�������
        // ������������򼯾���ע��(δ����)
        //var assemblysServices = Assembly.Load("ʵ����"); // ����ע��ı���Ҫ��ʵ���� Load�����������
        //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces(); // ɨ����������Ϊ�ṩ������ʵ�ֵĽӿ�
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
<<<<<<< HEAD
        app.UseCors("AllowOrigin");
        // app.UseAuthentication();
=======
        app.UseAuthentication();
>>>>>>> cd2dff46a4fc0a3f99d221fe23302866333e5894
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