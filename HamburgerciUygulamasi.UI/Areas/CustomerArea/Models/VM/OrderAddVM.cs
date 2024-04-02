using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Enums;

namespace HamburgerciUygulamasi.UI.Areas.CustomerArea.Models.VM
{
    public class OrderAddVM
    {
        
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public List<Guid> MenuIds { get; set; }
        public List<Guid> ExtraIds { get; set; }
    }
}
