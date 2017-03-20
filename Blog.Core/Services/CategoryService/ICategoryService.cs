namespace Blog.Core.Services
{
    using Blog.Domain;
    using Blog.Dto;

    public interface ICategoryService: IServiceBase<Category, CategoryDto>
    {
    }
}
