using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.UI.Areas.AdminArea.Models.VM;
using HamburgerciUygulamasi.DAL.Enums;

namespace HamburgerciUygulamasi.UI.Areas.CustomerArea.Models.VM
{
    public class OrderEditVM
    {
        public OrderEditItem OrderEditItem { get; set; }
        public List<Menu>? Menus { get; set; }
        public List<Extra>? Extras { get; set; }
    }
    public class OrderEditItem
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public List<Guid> Menu { get; set; }
        public List<Guid> Extra { get; set; }

    }
}
