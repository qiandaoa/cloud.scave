using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Admin.Domain.Entity.System;
using Admin.Domain.ObjectValue;
using Microsoft.IdentityModel.Tokens;

namespace Admin.Domain.DomainService
{
    public class AuthDomainService : IAuthDomainService
    {
        private readonly IAppUserDomainService _appUserDomainService;
        private readonly JwtSetting _jwtSettings;

        public AuthDomainService(IAppUserDomainService appUserDomainService, JwtSetting jwtSettings)
        {
            _appUserDomainService = appUserDomainService;
            _jwtSettings = jwtSettings;
        }

        public DomainResult<string> Login(string username, string password)
        {
            // 根据用户名获取数据
            var res = _appUserDomainService.GetUserByUsername(username);
            // 如果用户存在
            if(res.IsSuccess){
                var user = res.Data;
                // 如果该用户被删除
                if(user.IsDeleted){
                    return DomainResult<string>.Error("用户已被删除");
                }
                // 如果该用户被禁用
                if(user.IsActived){
                    return DomainResult<string>.Error("用户已被禁用");
                }
                // 如果验证密码不成功
                if(user.ValidatePassword(password)){
                    var token = GenerateJwtToken(user);
                    return DomainResult<string>.Success(token);
                }
                return DomainResult<string>.Error("账号或密码不正确，请重新输入");
            }
            return DomainResult<string>.Error("账号或密码不正确，请重新输入");
        }
        // 登出
        public void Logout()
        {
            throw new NotImplementedException();
        }
        // 根据用户信息，生成token
        private string GenerateJwtToken(AppUser user)
        {
            // claims是包含有关用户身份和其他信息的声明
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            // 创建一个对称加密密钥对象key，使用_jwtSettings.SecretKey生成加密密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // 使用上一步生成的密钥key创建签名凭据creds，使用HMACSHA256 算法进行签名
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 创建 JwtSecurityToken 对象 token 来生成JWT令牌
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer, // JWT的发行者
                audience: _jwtSettings.Audience, // JWT的接收者
                claims: claims, // 声明
                expires: DateTime.Now.AddHours(3), // 有效期 三个小时后过期
                signingCredentials: creds // 签名凭据
            );
            // 使用 JwtSecurityTokenHandler 的 WriteToken 方法将 JwtSecurityToken 对象 token 转换为字符串形式的 JWT 令牌，并返回给调用者
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
