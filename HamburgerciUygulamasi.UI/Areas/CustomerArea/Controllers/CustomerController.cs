using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerciUygulamasi.UI.Areas.CustomerArea.Controllers
{
    [Authorize(Roles = "customer")]
    [Area("CustomerArea")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
