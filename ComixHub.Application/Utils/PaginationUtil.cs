using AutoMapper;
using ComixHub.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace ComixHub.Application.Utils
{
    public class PaginationUtil
    {
        public static IEnumerable<TDestination> Paginate<TSource, TDestination>(IEnumerable<TSource> items, IHttpContextAccessor contextAccessor, IMapper mappper)
        {
            contextAccessor.HttpContext.Response.Headers.Add("total-items-count", items.Count().ToString());
            return items.MapTo<TDestination>(mappper);
        }
    }
}
