using System.Text;
using Admin.Application.AppUser;
using Admin.Application.Contracts.AppUser;
using Admin.Domain.DomainService;
using Admin.Domain.Interface;
using Admin.Domain.ObjectValue;
using Admin.EntityFrameworkCore;
using Admin.EntityFrameworkCore.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;


namespace Admin.Api;
public class Startup
{
  private readonly IConfiguration _config;
  public Startup(IConfiguration config)
  {
    _config = config;
  }
  public void Configure(IApplicationBuilder app)
  {
    app.UseRouting();
    app.UseEndpoints(endpoints => {
      endpoints.MapControllers();
    });
  }
  public void ConfigureServices(IServiceCollection services)
  {
      // 从配置文件中获取"JwtSetting"的部分，并将其映射到名为JwtSetting的实例jwtSetting中
      var jwtSettings = _config.GetSection("JwtSetting").Get<JwtSetting>();
      // 检查jwtSetting是否为null
      // 如果为null就创建一个新的JwtSetting实例，并为其设置默认值
      // ??= 是空合并赋值运算符，用于给变量赋值前先检查其是否为 null
      jwtSettings ??= new JwtSetting{Issuer = "hxf",Audience="hxf",SecretKey="hxf"};
      // 配置应用程序的身份验证服务
      services.AddAuthentication(options => {
        // 指定JWT作为默认的身份验证方案，并使用JWT Bearer认证方案
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      // 配置JWT Beare认证的方法
      .AddJwtBearer(options => {
         //  表示在开发环境或未使用 HTTPS 的环境中允许 JWT 认证
         options.RequireHttpsMetadata = false;
         //  在身份验证后，将Token保存
         options.SaveToken = true;
         //  配置JWT验证参数
         options.TokenValidationParameters = new TokenValidationParameters(){
             ValidateIssuer = true, // 发行者
             ValidateAudience = true, // 接受者
             ValidateLifetime = true, // Token有效期
             ValidateIssuerSigningKey = true, // 签名密钥
             ValidIssuer = jwtSettings.Issuer,
             ValidAudience = jwtSettings.Audience,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
         };
      });
      // 将JwtSetting实例注册到容器
      // 注册为单例服务，以便在应用程序的其他部分也可以注入和使用实例
      services.AddSingleton(jwtSettings);

      // 注册控制器
      services.AddControllers();
      
      // 注册接口
      services.AddScoped(typeof(IRepository<>),typeof(EfRepository<>));
      services.AddScoped(typeof(IAppUserAppService),typeof(AppUserAppService));
      services.AddScoped(typeof(IAuthDomainService), typeof(AuthDomainService));
      services.AddScoped(typeof(IAppUserDomainService),typeof(AppUserDomainService));
      
      // 注册数据库上下文
      services.AddDbContext<AdminDbContext>(opt => {
        opt.UseNpgsql(_config.GetConnectionString("pg"));
      });

      // 配置Serilog日志记录器，将其集成到应用程序中
      // 创建Serilog日志记录器配置
      Log.Logger = new LoggerConfiguration()
                  .WriteTo.Console()  // 指定日志输出到控制台
                  .CreateLogger();  // 创建实际的 Serilog 日志记录器对象
      // Serilog 集成到应用程序中，以便 Serilog 可以在整个应用程序中捕获和处理日志信息
      services.AddSerilog(); 
  }
}