namespace Blog.Mapper.DtoEntity
{
    using AutoMapper;
    public static class DtoEntityMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new CommonMapper());
            });
        }
    }
}
