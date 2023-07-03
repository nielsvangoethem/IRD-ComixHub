namespace ComixHub.Application.Issues.DTOs
{
    public class IssueDetailItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PublishDate { get; set; }
        public int IssueNumber { get; set; }
        public string Imprint { get; set; }
        public string Rating { get; set; }
        public string Price { get; set; }
        public string Writer { get; set; }
        public string Inker { get; set; }
        public string Colorist { get; set; }
        public string Letterer { get; set; }
        public string Penciler { get; set; }
        public string Editor { get; set; }
    }
}
