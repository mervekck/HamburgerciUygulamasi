using HamburgerciUygulamasi.DAL.Entities.Interfaces;
using HamburgerciUygulamasi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Abstract
{
    public class EntityBase : IEntity<Guid>, IEntityBase
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int AutoId { get; set; }
    }
}
