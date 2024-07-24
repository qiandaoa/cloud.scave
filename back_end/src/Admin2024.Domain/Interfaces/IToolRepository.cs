using Admin2024.Instructions;

namespace Admin2024.Domain.Interfaces;

//通用工具接口
public interface IToolRepository<T>where T : BaseEntity
{
     List<T> PagingAny(List<T> query, int? PageNumber, int? PageSize);
}