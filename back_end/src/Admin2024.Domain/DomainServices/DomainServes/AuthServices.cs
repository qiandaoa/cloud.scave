using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Admin2024.Domain.ObjectValue;
using Admin2024.Domain.System;
using Microsoft.IdentityModel.Tokens;


namespace Admin2024.Domain.DomainServices;

public class AuthServices : IAuthServices
{
    private readonly IUserDomainService _userDomainService;
    private readonly JwtSetting _jwtSetting;

    public AuthServices(IUserDomainService userDomainService, JwtSetting jwtSetting)
    {
        _userDomainService = userDomainService;
        _jwtSetting = jwtSetting;
    }
    public string Login(User user)
    {
        return GenerateJwtToken(user);
    }

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
            expires: DateTime.Now.AddMinutes(_jwtSetting.ExpirationMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
