namespace Blog.Domain
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Article> Article { get; set; }
    }
}
