namespace ComixHub.Infrastructure.Interfaces
{
    public interface ISortableQuery
    {
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
    }
}
