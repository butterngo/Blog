namespace Blog.Core
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class WebApiUserStore : UserStore<User, Roles, BlogContext, string>
    {
        public WebApiUserStore(BlogContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
