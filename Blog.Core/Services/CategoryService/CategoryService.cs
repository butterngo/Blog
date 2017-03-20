namespace Blog.Core.Services
{
    using Blog.Domain;
    using Blog.Dto;

    public class CategoryService : ServiceBase<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
