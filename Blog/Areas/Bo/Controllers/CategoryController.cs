namespace Blog.FontEnd.Areas.Bo.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Blog.ViewModel.Bo;
    using Blog.Core.Services;
    using Blog.Dto;

    public class CategoryController : BaseController<ICategoryService>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            @ViewBag.Action = "Create";
            return View("CreateEditCategory", new CategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.CreateAsync(VmToDto<CategoryViewModel, CategoryDto>(model));

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            @ViewBag.Action = "Edit";

            var model = await _service.FindByIdAsync(id);

            if (model == null) return NotFound();

            return View("CreateEditCategory", DtoToVm<CategoryViewModel, CategoryDto>(model));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.UpdateAsync(VmToDto<CategoryViewModel, CategoryDto>(model));

            return RedirectToAction("index");
        }
    }
}