namespace ComixHub.Core.Filters
{
    public class QueryParameters<TFilters> where TFilters : EntityFilters
    {
        public TFilters Filters { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; } = false;
    }
}
