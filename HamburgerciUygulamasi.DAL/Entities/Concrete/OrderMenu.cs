using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class OrderMenu
    {
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
