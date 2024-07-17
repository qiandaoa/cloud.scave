using System.Text;
using Admin2024.Application.AppService;
using Admin2024.Application.Contracts.AutoMapper;
using Admin2024.Application.Contracts.UserApplication.Interface;
using Admin2024.Domain.DomainServices;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.ObjectValue;
using Admin2024.EntityFramework;
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
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endPoints =>
        {
            endPoints.MapControllers();
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
        });
        var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSetting>();
        // 如果为空则自己new一个，确保不为空
        jwtSettings ??= new JwtSetting { Issuer = "xyz", Audience = "xyz", SecretKey = "xyz" };
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            };
        });
        services.AddAutoMapper(typeof(UserProfile));
        // 将JwtSetting实例注册到容器
        services.AddSingleton(jwtSettings);
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