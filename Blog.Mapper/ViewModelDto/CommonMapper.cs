namespace Blog.Mapper.ViewModelDto
{
    using AutoMapper;
    using Blog.Dto;
    using Blog.ViewModel.Bo;

    public class CommonMapper : Profile
    {
        public CommonMapper()
        {
            #region ViewModel To Dto
            CreateMap<CategoryViewModel, CategoryDto>();
            #endregion

            #region Dto To ViewModel
            CreateMap<CategoryDto, CategoryViewModel>();
            #endregion
        }
    }
}
