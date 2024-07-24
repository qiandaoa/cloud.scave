using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin2024.EntityFramework.Helps
{
    public class Pagination
    {
        public static void GetPagination(BaseParameters baseParameters, int totalPages, int totalCount, IUrlHelper Url,HttpResponse response)
        {
            var pagination = new
            {
                pageIndex = baseParameters.PageIndex,
                pageSize = baseParameters.PageSize,
                totalPages,
                totalCount,
                previousPage = baseParameters.PageIndex == 1 ? null : Url.Link("GetAllUsers", new
                {
                    pageIndex = baseParameters.PageIndex - 1,
                    pageSize = baseParameters.PageSize,
                    keywords = baseParameters.keywords,
                }),
                nextPage = baseParameters.PageIndex < totalPages ? Url.Link("GetAllUsers", new
                {
                    pageIndex = baseParameters.PageIndex + 1,
                    pageSize = baseParameters.PageSize,
                    keywords = baseParameters.keywords,
                }) : null
            };
            response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagination));
        }
    }
}

  