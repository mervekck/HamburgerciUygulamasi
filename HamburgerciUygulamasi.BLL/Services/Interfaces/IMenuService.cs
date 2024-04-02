using HamburgerciUygulamasi.BLL.Repositories.BaseRepository;
using HamburgerciUygulamasi.DAL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.BLL.Services.Interfaces
{
    public interface IMenuService : IRepository<Menu>
    {
    }
}
