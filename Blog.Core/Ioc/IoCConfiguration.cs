using Blog.Common.Factories;
namespace Blog.Core.Ioc
{
    using Blog.Core.Services;
    using Microsoft.Extensions.DependencyInjection;

    public class IoCConfiguration
    {
        public static void RegisterIoC(IServiceCollection services)
        {
            services.AddScoped<WebApiUserManager, WebApiUserManager>();

            services.AddScoped<WebApiRoleManager, WebApiRoleManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IDashbroadService, DashbroadService>();

            ResolverFactory.SetProvider(services.BuildServiceProvider());
        }
    }
}
