using Admin2024.Domain.System;

namespace Admin2024.Domain.DomainServices;

public interface IAuthServices
{
    string Login(User user);
}