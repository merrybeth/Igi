using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> roleManager;
        private EmailController _emailService;
        
        private AppDBContent _appDbContent;


        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,EmailController emailService)
        {
            this.roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
            [Route("/loginGoogle")]
        public IActionResult LoginGoogle()
        {
           return Challenge(new AuthenticationProperties {RedirectUri = "/"}, "Google");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
           
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                if (result.Succeeded) return RedirectToAction("Index", "Home");
                
                ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
            }

            return View(model);
        }


        // public async Task<IActionResult> AddUserToAdmins()
        // {
        //     await roleManager.CreateAsync(new IdentityRole("admin"));
        //     ApplicationUser user = await _userManager.FindByEmailAsync(""); //enter email
        //     await _userManager.AddToRoleAsync(user, "admin");
        //     return Redirect("/");
        // }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {Email = model.Email, UserName = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new {userId = user.Id, code = code},
                        protocol: HttpContext.Request.Scheme);
                  
                    await _emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                    return Content(
                        "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Error("Не правильный код подтвержения");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Error("Такой пользователь не был найден");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            return Error("Ошибка, попробуйте позже");
        }
        
        public ActionResult Error(string text = "",string text_main = "")
        {
            TempData["text"] = text;
            TempData["text_main"] = text_main;
            return View();
        }
    }
}