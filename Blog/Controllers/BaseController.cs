namespace Blog.FontEnd.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public abstract class BaseController: Controller
    {
        protected readonly string _userId;

        public BaseController()
        {
            _userId = (User == null ? string.Empty : User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
