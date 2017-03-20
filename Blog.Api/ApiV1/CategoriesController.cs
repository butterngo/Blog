namespace Blog.Api.ApiV1
{
    using Blog.Core.Services;
    using Blog.Domain;
    using Blog.Dto;
    using Microsoft.AspNetCore.Mvc;

    [Route("apiv1/[controller]")]
    public class CategoriesController : BaseController<Category, CategoryDto, ICategoryService>
    {
        public CategoriesController(ICategoryService service) : base(service)
        {
        }
    }
}
