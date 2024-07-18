using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Admin2024.Domain.Interfaces;
using Admin2024.Domain.ObjectValue;
using Admin2024.Domain.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


namespace Admin2024.Domain.DomainServices;

public class AuthServices : IAuthServices
{
    private readonly IUserDomainService _userRepo;
    private readonly JwtSetting _jwtSetting;

    public AuthServices(IUserDomainService repository, JwtSetting jwtSetting)
    {
        _userRepo = repository;
        _jwtSetting = jwtSetting;
    }
    /// <summary>
    /// ��¼
    /// </summary>
    /// <param name="username">�˺�</param>
    /// <param name="password">����</param>
    /// <returns></returns>
    public string? Login(string username, string password)
    {
        var entity = _userRepo.GetByUsername(username);

        if (entity != null && password == entity.Password)
        {
            var token = GenerateJwtToken(entity);

            return token;
        }
        return null;
    }
    /// <summary>
    /// ��ȡtoken
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Username),
            new Claim(JwtRegisteredClaimNames.Jti,user.Id.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _jwtSetting.Issuer,
            audience: _jwtSetting.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
