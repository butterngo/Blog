namespace Blog.FontEnd.Areas.Bo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Blog.Core.Services;

    public class DashbroadController : BaseController<IDashbroadService>
    {
        public DashbroadController(IDashbroadService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}