
using Admin2024.Domain.System;

namespace Admin2024.Domain.DomainServices;

public interface IUserDomainService
{
    User? GetByUsername(string username);
    User? GetUserById(Guid id);
    Task Register(User user);
    Task ResetPassword(User user);
}