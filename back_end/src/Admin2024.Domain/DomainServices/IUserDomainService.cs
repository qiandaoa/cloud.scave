
using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;

public interface IUserDomainService
{
    User? GetByUsername(string username);
    User? GetUserById(Guid id);
    Task Register(User user);
    Task ModifyPassword(User user);
}