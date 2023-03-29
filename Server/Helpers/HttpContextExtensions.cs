using Tool.Shared.Models;

namespace Tool.Server.Helpers {
    public static class HttpContextExtensions 
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
            PaginationDTO pagination) {
            return queryable
                .Skip((pagination.Page - 1) * pagination.QuantityPerPage)
                .Take(pagination.QuantityPerPage);
        }
    }
}
