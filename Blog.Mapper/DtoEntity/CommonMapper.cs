namespace Blog.Mapper.DtoEntity
{
    using AutoMapper;
    using Blog.Domain;
    using Blog.Dto;

    public class CommonMapper: Profile
    {
        public CommonMapper()
        {
            #region Enity To Dto

            CreateMap<Category, CategoryDto>();

            CreateMap<Article, ArticleDto>();

            CreateMap<Tag, TagDto>();

            CreateMap<BlogFile, BlogFileDto>();

            CreateMap<ArticleTagMap, ArticleTagMapDto>();

            #endregion

            #region Dto To Entity

            CreateMap<CategoryDto, Category>();

            CreateMap<ArticleDto, Article>();

            CreateMap<TagDto, Tag>();

            CreateMap<BlogFileDto, BlogFile>();

            CreateMap<ArticleTagMapDto, ArticleTagMap>();

            #endregion
        }
    }
}
