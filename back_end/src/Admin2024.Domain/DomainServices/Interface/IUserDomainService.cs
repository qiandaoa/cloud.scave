
using Admin2024.Domain.System;
using Admin2024.Instructions;
namespace Admin2024.Domain.DomainServices.Interface;

public interface IUserDomainService
{
    User? GetByUsername(string username);
    User? GetUserById(Guid id);
    Task Register(User user);
    Task ModifyPassword(User user);
    Task<User> UserAdd(User user);
}