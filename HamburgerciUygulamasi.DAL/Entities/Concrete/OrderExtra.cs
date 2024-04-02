using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class OrderExtra
    {
        public Guid ExtraId { get; set; }
        public virtual Extra Extra { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
