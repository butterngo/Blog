namespace Blog.FontEnd.Areas.Bo.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc.Filters;
    using AutoMapper;

    [Area("bo")]
    [Authorize]
    public abstract class BaseController<TService> : Controller
        where TService: class
    {
        protected string UserId { get; set; }

        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            UserId = (User == null ? string.Empty : User.FindFirstValue(ClaimTypes.NameIdentifier));

            ViewBag.UserId = (User == null ? string.Empty : User.Identity.Name);

            base.OnActionExecuted(context);
        }

        protected TDto VmToDto<TViewModel, TDto>(TViewModel vm)
        {
            return Mapper.Map<TDto>(vm);
        }

        protected TViewModel DtoToVm<TViewModel, TDto>(TDto vm)
        {
            return Mapper.Map<TViewModel>(vm);
        }
    }
}