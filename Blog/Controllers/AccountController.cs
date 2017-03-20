namespace Blog.FontEnd.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Blog.Core;
    using Blog.ViewModel.FE;
    using Microsoft.AspNetCore.Identity;

    public class AccountController : BaseController
    {
        private readonly WebApiUserManager _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(WebApiUserManager userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            //var result = await _userManager.CreateAsync(new Core.User { UserName = "admin", Email = "ngovu.dl@gmail.com" }, "admin");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _userManager.CreateAsync(new Core.User { UserName = "admin", Email = "ngovu.dl@gmail.com" }, "admin");

            return RedirectToAction("Success");
        }



        [HttpGet]
        public IActionResult Login()
        {
            //var result = await _userManager.CreateAsync(new Core.User { UserName = "admin", Email = "ngovu.dl@gmail.com" }, "admin");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemember, false);

            return Redirect(model.ReturnUrl);
        }

    }
}