using Admin.Domain.ObjectValue;

namespace Admin.Domain.DomainService;
public interface IAuthDomainService
{
  DomainResult<string> Login(string username, string password);
  void Logout();
}