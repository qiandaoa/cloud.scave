using System.Security.Cryptography;
using System.Text;
using System.Xml.Schema;

namespace Admin2024.Domain.DomainServices.Services;

public class PasswordHelper
{
    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using (var hmac = new HMACSHA256(saltBytes))
        {
            byte[] hashedBytes = hmac.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public static string GenerateSalt()
    {
        byte[] saltBytes = new byte[16];
        using(RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }
}