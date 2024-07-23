using Admin2024.Domain.System;
using Admin2024.Instructions;

namespace Admin2024.Domain.DomainServices;
public interface IResourceServices
{
     Task<ReturnResult<Resource>> CreateResource();
}