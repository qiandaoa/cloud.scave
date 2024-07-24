
using Admin2024.Domain;
using Admin2024.Domain.Interfaces;
using Admin2024.Domain.System;
using Admin2024.Instructions;
using System.Linq;

using Microsoft.EntityFrameworkCore;


namespace Admin2024.EntityFramework;

public class ToolRepository<T> : IToolRepository<T> where T : BaseEntity
{
    public List<T> PagingAny(List<T> query, int? PageNumber, int? PageSize)
    {
        PageNumber = PageNumber ?? 1;
        PageSize = PageSize ?? 10;

        if (PageNumber <= 0) PageNumber = 1;
        if (PageSize <= 0) PageSize = 10;

        var pagedData = query.Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value).ToList();

        return pagedData;
    }
}