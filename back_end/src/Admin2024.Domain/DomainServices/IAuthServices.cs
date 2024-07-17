namespace Admin2024.Domain.DomainServices;

public interface IAuthServices
{
    string? Login(string username,string password);
}