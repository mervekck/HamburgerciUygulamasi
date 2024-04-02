using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;
using HamburgerciUygulamasi.UI.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerciUygulamasi.UI.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<AppUser> _signInManager;
        public RoleManager<AppRole> _roleManager;
        public UserManager<AppUser> _userManager;
        IConfiguration configuration;

        public AccountController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            configuration = config;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = new AppUser();
                    user.Email = vm.Email;
                    user.UserName = vm.UserName;
                    user.PhoneNumber = vm.PhoneNumber;
                    user.TwoFactorEnabled = false;
                    user.EmailConfirmed = false;
                    var result = await _userManager.CreateAsync(user, vm.Password);
                    if (result.Succeeded)
                    {
                        /////////////////////////////////////////////
                        await _userManager.AddToRoleAsync(user, "customer");
                        /////////////////////////////////////////////
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        TempData["message"] = "Kayıt işlemi başarıyla tamamlandı.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {


                }
            }
            TempData["message"] = "Kayıt olma işlemi başarısız.";
            return View(vm);

        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVM vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(vm.UserName);
                ViewData["UserName"] = user.UserName;
                if (TempData["ReturnUrl"] != null)
                {
                    string[] url = TempData["ReturnUrl"].ToString().Trim('/').Split('/');
                    if (url.Length > 2)
                    {
                        return RedirectToAction(url[2], url[1], new { area = url[0] });
                    }
                    else
                    {
                        return RedirectToAction(url[1], url[0]);

                    }
                }
                return RedirectToAction("Index", "Home");

            }

            TempData["message"] = "Kullanıcı Adı yada Şifre Hatalı";
            return View(vm);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        

    }
}
