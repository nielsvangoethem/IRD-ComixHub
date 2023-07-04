using AutoMapper;
using System.Collections;

namespace ComixHub.Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        public static TDestination MapTo<TDestination>(this object source, IMapper mapper)
        {
            return mapper.Map<TDestination>(source);
        }

        public static IEnumerable<TDestination> MapTo<TDestination>(this IEnumerable source, IMapper mapper)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}
