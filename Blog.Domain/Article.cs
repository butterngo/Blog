namespace Blog.Domain
{
    using System;

    public class Article: IAudits
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string DefaultImage { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string Publisher { get; set; }
        public int Visits { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
