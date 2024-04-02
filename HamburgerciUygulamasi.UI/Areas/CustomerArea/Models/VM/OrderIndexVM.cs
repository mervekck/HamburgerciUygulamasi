using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;

namespace HamburgerciUygulamasi.UI.Areas.CustomerArea.Models.VM
{
    public class OrderIndexVM
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public string NameMenus { get; set; }
        public string NameExtras { get; set; }
    }
}
