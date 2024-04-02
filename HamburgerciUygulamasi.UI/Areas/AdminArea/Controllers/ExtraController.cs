using AutoMapper;
using HamburgerciUygulamasi.BLL.Services.Interfaces;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;
using HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace HamburgerciUygulamasi.UI.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("AdminArea")]
    public class ExtraController : Controller
    {
        IExtraService extraService;
        IMapper mapper;
        public ExtraController(IExtraService service, IMapper mapper)
        {
            extraService = service;
            this.mapper = mapper;
        }
        public IActionResult Index(ExtraIndexVM vm)
        {

            List<Extra> extras;

            if (vm.IsEnter.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(vm.Name))
                {
                    extras = extraService.GetBy(x => x.Name.Contains(vm.Name) && x.Status == Status.Active).ToList();
                    return View(vm);
                }
            }

            vm = new ExtraIndexVM();
            extras = extraService.GetBy(x => x.Status == Status.Active).ToList();
            vm.Extras = mapper.Map<List<ExtraIndexItem>>(extras);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ExtraAddVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Extra extra = mapper.Map<Extra>(vm);

                    extra.Status = Status.Active;
                    extra.CreatedDate = DateTime.Now;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        vm.Picture_.CopyTo(ms);
                        extra.Picture = ms.ToArray();
                    }

                    extraService.Add(extra);

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
            Extra extra = extraService.Find(id);
            ExtraEditVM vm = mapper.Map<ExtraEditVM>(extra);
            
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(ExtraEditVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var extra = extraService.Find(vm.Id);
                    extra = mapper.Map(vm, extra);
                    if (vm.Picture_ != null && vm.Picture_.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            vm.Picture_.CopyTo(ms);
                            extra.Picture = ms.ToArray();
                        }
                    }
                    extraService.Edit(extra);
                    
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
                Extra extra = extraService.Find(id);
                extraService.Remove(extra);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }

    }
}
