using HamburgerciUygulamasi.DAL.Entities.Abstract;
using HamburgerciUygulamasi.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgerciUygulamasi.DAL.Enums;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class Order : EntityBase, IEntity<Guid>
    {
        public Size Size { get; set; }        
        public int Quantity { get; set; }
        public virtual List<OrderMenu> OrderMenus { get; set; }
        public virtual List<OrderExtra> OrderExtras { get; set; }
    }
}
