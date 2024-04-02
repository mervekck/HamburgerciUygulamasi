using HamburgerciUygulamasi.BLL.Repositories.Concrete;
using HamburgerciUygulamasi.BLL.Services.Interfaces;
using HamburgerciUygulamasi.DAL.Context;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.BLL.Services.Concretes
{
    public class OrderExtraService : BaseRepository<OrderExtra>, IOrderExtraService
    {
        public OrderExtraService(HamburgerciDbContext context) : base(context)
        {

        }
    }
}
