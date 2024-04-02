using AutoMapper;
using HamburgerciUygulamasi.BLL.Services.Concretes;
using HamburgerciUygulamasi.BLL.Services.Interfaces;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;
using HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM;
using HamburgerciUygulamasi.UI.Areas.CustomerArea.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace HamburgerciUygulamasi.UI.Areas.CustomerArea.Controllers
{
    [Authorize(Roles = "customer")]
    [Area("CustomerArea")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        IExtraService extraService;
        IMenuService menuService;
        private readonly IMapper mapper;
        IOrderMenuService omService;
        IOrderExtraService oeService;

        public OrderController(IOrderService orderService, IExtraService extraService, IMenuService menuService, IOrderMenuService omService, IOrderExtraService oeService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
            this.menuService = menuService;
            this.extraService = extraService;
            this.oeService = oeService;
            this.omService = omService;
        }
        public IActionResult Index()
        {
            List<OrderIndexVM> vm = new();
            var orderList = orderService.GetBy(x => x.Status == Status.Active);
            foreach (var item in orderList)
            {
                var order = new OrderIndexVM();
                order.Size = item.Size;
                order.Quantity = item.Quantity;

                var OrderMenu = omService.GetBy(x => x.OrderId == item.Id);
                if (OrderMenu != null && OrderMenu.Count > 0)
                {
                    foreach (var om in OrderMenu)
                    {
                        order.NameMenus += $"{menuService.Find(om.MenuId).Name},";
                    }
                    order.NameMenus = order.NameMenus.Trim(',');
                }





                var OrderExtra = oeService.GetBy(x => x.OrderId == item.Id);
                if (OrderExtra != null && OrderExtra.Count > 0)
                {
                    foreach (var oe in OrderExtra)
                    {
                        order.NameExtras += $"{extraService.Find(oe.ExtraId).Name},";
                    }
                    order.NameMenus = order.NameMenus.Trim(',');
                }
                order.Id = item.Id;
                vm.Add(order);
            }
                return View(vm);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var menus = menuService.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            var extras = extraService.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

            ViewBag.Menu = menus;
            ViewBag.Extra = extras;

            return View();
        }
        [HttpPost]
        public IActionResult Add(OrderAddVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = mapper.Map<Order>(vm);
                    order.Status = Status.Active;


                    orderService.Add(order);

                    if (vm.MenuIds != null)
                    {
                        var orderId = order.Id;
                        foreach (var menuId in vm.MenuIds)
                        {
                            var orderMenu = new OrderMenu
                            {
                                OrderId = orderId,
                                MenuId = menuId
                            };
                            omService.Add(orderMenu);
                        }
                    }

                    if (vm.ExtraIds != null)
                    {
                        var orderId = order.Id;
                        foreach (var extraId in vm.ExtraIds)
                        {
                            var orderExtra = new OrderExtra
                            {
                                OrderId = orderId,
                                ExtraId = extraId
                            };
                            oeService.Add(orderExtra);
                        }
                    }

                    TempData["message"] = "Post Ekleme İşlemi Başarılı";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //TODO:Mail at
                    TempData["message"] = "Post Ekleme İşlemi Başarısız";
                }
            }


            TempData["message"] = $"Bir Hata Oluştu";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            try
            {
                OrderEditVM vm = new();
                vm.Extras = extraService.GetAll();
                vm.Menus = menuService.GetAll();
                ValidateOrderId(id);
                var selectedOrder = orderService.Find(id);
                selectedOrder.OrderMenus = omService.GetBy(x => x.OrderId == selectedOrder.Id);
                selectedOrder.OrderExtras = oeService.GetBy(x => x.OrderId == selectedOrder.Id);
                ValidateOrder(selectedOrder);

                OrderEditItem editOrder = mapper.Map<OrderEditItem>(selectedOrder);

                if (selectedOrder.OrderMenus != null && selectedOrder.OrderMenus.Count > 0)
                {
                    editOrder.Menu = new List<Guid>();
                    foreach (var item in selectedOrder.OrderMenus)
                    {
                        editOrder.Menu.Add(item.MenuId);
                    }
                }
                if (selectedOrder.OrderExtras != null && selectedOrder.OrderExtras.Count > 0)
                {
                    editOrder.Extra = new List<Guid>();
                    foreach (var item in selectedOrder.OrderExtras)
                    {
                        editOrder.Extra.Add(item.ExtraId);
                    }
                }

                vm.OrderEditItem = editOrder;
                return View(vm);
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }


        public void ValidateOrderId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Id hatalı olarak geldi, bu yüzden güncelleme devam edemez");
            }
        }

        public void ValidateOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception("veritabanında aranan order bulunamadı, bu yüzden güncelleme devam edemez");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderEditVM vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Order order = orderService.Find(vm.OrderEditItem.Id);
                    order = mapper.Map<Order>(vm.OrderEditItem);


                    order.OrderMenus = new List<OrderMenu>();
                    order.OrderExtras = new List<OrderExtra>();

                    OrderMenuDelete(order.Id);
                    OrderExtraDelete(order.Id);

                    foreach (var item in vm.OrderEditItem.Menu)
                    {
                        var menu = menuService.Find(item);
                        order.OrderMenus.Add(new OrderMenu { Menu = menu, Order = order });
                    }
                    foreach (var item in vm.OrderEditItem.Extra)
                    {
                        var extra = extraService.Find(item);
                        order.OrderExtras.Add(new OrderExtra { Extra = extra, Order = order });
                    }
                    order.ModifiedDate = DateTime.Now;
                    orderService.Edit(order);
                    TempData["message"] = "Order Edit İşlemi Başarılı";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["message"] = "Order Edit İşlemi Başarısız";
                    return View(vm);
                }
            }
            TempData["message"] = "Order ile ilgili tüm elemanlara veri giriniz";
            return View(vm);
        }

        public void OrderMenuDelete(Guid id)
        {
            var list = omService.GetBy(x => x.OrderId == id);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    omService.Remove(item);
                }
            }
        }
        public void OrderExtraDelete(Guid id)
        {
            var list = oeService.GetBy(x => x.OrderId == id);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    oeService.Remove(item);
                }
            }
        }


        public IActionResult Remove(Guid id)
        {
            try
            {
                Order order = orderService.Find(id);
                orderService.Remove(order);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
