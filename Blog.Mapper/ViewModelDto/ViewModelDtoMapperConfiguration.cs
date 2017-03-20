namespace Blog.Mapper.ViewModelDto
{
    using AutoMapper;
    public static class ViewModelDtoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new CommonMapper());
            });
        }
    }
}
