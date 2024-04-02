using HamburgerciUygulamasi.DAL.Entities.Abstract;
using HamburgerciUygulamasi.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class Extra : EntityBase, IEntity<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }
        public virtual List<OrderExtra> OrderExtras { get; set; }
        
    }
}
