using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Blog.Core;
using Microsoft.EntityFrameworkCore;
using Blog.Common;
using Blog.Common.Factories;
using WebApi.JWT;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Blog.Core.Ioc;
using Blog.Mapper.DtoEntity;
using Blog.Mapper.ViewModelDto;

namespace Blog
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            HelperAppSettings helperAppSettings = new HelperAppSettings(Configuration);

            ViewModelDtoMapperConfiguration.Config();

            DtoEntityMapperConfiguration.Config();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<BlogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Blog"), b => b.MigrationsAssembly("Blog.Core")));

            services.AddIdentity<User, Roles>(Options => WebApiUserManager.CreateOptions(Options))
                    .AddEntityFrameworkStores<BlogContext>()
                    .AddDefaultTokenProviders();

            IoCConfiguration.RegisterIoC(services);

            services.Configure<AppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var secretKey = "mysupersecret_secretkey!123";

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseIdentity();

            ConfigMvcAuthentication(app, tokenValidationParameters);

            SetupOauth(app, tokenValidationParameters, signingKey);

            ConfigMvcRouter(app);

        }

        private void ConfigMvcAuthentication(IApplicationBuilder app, TokenValidationParameters tokenValidationParameters)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                AuthenticationScheme = "Cookie",
                CookieName = "access_token",
                TicketDataFormat = new TokenProvider(
                    SecurityAlgorithms.HmacSha256,
                    tokenValidationParameters)
            });
        }

        private void SetupOauth(IApplicationBuilder app, TokenValidationParameters tokenValidationParameters, SymmetricSecurityKey signingKey)
        {
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters,
                Events = new JwtEvents(tokenValidationParameters)
            });
        }

        private void ConfigMvcRouter(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Account}/{action=Login}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
