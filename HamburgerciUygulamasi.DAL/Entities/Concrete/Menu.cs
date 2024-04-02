using HamburgerciUygulamasi.DAL.Entities.Abstract;
using HamburgerciUygulamasi.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class Menu : EntityBase, IEntity<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }
        public virtual List<OrderMenu> OrderMenus { get; set; }

        
    }
}
