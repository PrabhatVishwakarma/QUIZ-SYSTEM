using Microsoft.EntityFrameworkCore;

namespace Tool.Server.Helpers {
    public static class IQueryableExtensions 
    {
        public static async Task InsertPaginationParameterInResponse<T>(this HttpContext httpContext,
          IQueryable<T> queryable, int recordsPerPage) 
        {
            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
    }
}
