namespace Blog.Domain
{
    using System.Collections.Generic;

    public class ArticleTagMap
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public int TagId { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
