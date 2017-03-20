namespace Blog.ViewModel.Bo
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel: BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActive { get; set; }
    }
}
