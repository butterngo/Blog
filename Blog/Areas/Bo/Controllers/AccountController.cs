namespace Blog.FontEnd.Areas.Bo.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Blog.Core;
    using Blog.ViewModel.Bo;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    [Area("bo")]
    [Authorize]
    public class AccountController : Controller
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //var result = await _userManager.CreateAsync(new Core.User { UserName = "admin", Email = "ngovu.dl@gmail.com" }, "admin");

            return RedirectToAction("Success");
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemember, false);

                return RedirectToAction("Index", "Dashbroad");
            }

            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Login");
        }

    }
}