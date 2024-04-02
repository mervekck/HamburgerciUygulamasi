using AutoMapper;
using HamburgerciUygulamasi.BLL.Services.Concretes;
using HamburgerciUygulamasi.BLL.Services.Interfaces;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;
using HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminArea")]
    public class MenuController : Controller
    {
        IMenuService menuService;
        IMapper mapper;
        public MenuController(IMenuService service, IMapper mapper)
        {
            menuService = service;
            this.mapper = mapper;
        }
        public IActionResult Index(MenuIndexVM vm)
        {
            List<Menu> menus;

            if (vm.IsEnter.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(vm.Name))
                {
                    menus = menuService.GetBy(x => x.Name.Contains(vm.Name) && x.Status == Status.Active).ToList();
                    return View(vm);
                }
            }

            vm = new MenuIndexVM();
            menus = menuService.GetBy(x => x.Status == Status.Active).ToList();
            vm.Menus = mapper.Map<List<MenuIndexItem>>(menus);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MenuAddVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Menu menu = mapper.Map<Menu>(vm);

                    menu.Status = Status.Active;
                    menu.CreatedDate = DateTime.Now;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        vm.Picture_.CopyTo(ms);
                        menu.Picture = ms.ToArray();
                    }

                    menuService.Add(menu);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Menu menu = menuService.Find(id);
            MenuEditVM vm = mapper.Map<MenuEditVM>(menu);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(MenuEditVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var menu = menuService.Find(vm.Id);
                    menu = mapper.Map(vm, menu);
                    if (vm.Picture_ != null && vm.Picture_.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            vm.Picture_.CopyTo(ms);
                            menu.Picture = ms.ToArray();
                        }
                    }
                    menuService.Edit(menu);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }
        public IActionResult Remove(Guid id)
        {
            try
            {
                Menu menu = menuService.Find(id);
                menuService.Remove(menu);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
