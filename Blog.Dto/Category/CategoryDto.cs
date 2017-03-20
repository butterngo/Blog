namespace Blog.Dto
{
    using System.Collections.Generic;

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ArticleDto> Article { get; set; }
    }
}
