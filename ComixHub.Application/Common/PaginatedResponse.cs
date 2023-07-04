namespace ComixHub.Application.Common
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
    }
}
