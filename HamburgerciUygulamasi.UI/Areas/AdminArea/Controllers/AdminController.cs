using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminArea")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
