using HamburgerciUygulamasi.DAL.Entities.Interfaces;
using HamburgerciUygulamasi.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Concrete
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int AutoId { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
