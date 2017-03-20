namespace Blog.Dto
{
    using System.Collections.Generic;

    public class ArticleTagMapDto
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public ArticleDto Articles { get; set; }
        public int TagId { get; set; }
        public TagDto Tags { get; set; }
    }
}
