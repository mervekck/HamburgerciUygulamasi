using HamburgerciUygulamasi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Entities.Interfaces
{
    public interface IEntityBase
    {
        Status Status { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        int AutoId { get; set; }
    }
}
