using System.Text;
using Admin2024.Domain.ObjectValue;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Admin2024.Api.Extension;
public static class Swagger
{

    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            var basePath = AppContext.BaseDirectory; // 获取应用程序的基本目录路径
            var xmlPath = Path.Combine(basePath,"Admin2024.xml");  //将基本路径组成一个完成的路径
            c.IncludeXmlComments(xmlPath, true); // 表示将xml注释文件添加到swagger生成器中,xmlpath表示xml的位置.true表示启动xml的详细注释信息,默认值为false
        });
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSetting>();
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
        services.AddSingleton(jwtSettings);
    }
}