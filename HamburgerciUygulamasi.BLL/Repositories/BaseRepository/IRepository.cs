using HamburgerciUygulamasi.DAL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.BLL.Repositories.BaseRepository
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T item);
        void Edit(T item);
        void Remove(T item);

        List<T> GetAll();
        List<T> GetBy(Func<T, bool> exp);

        List<T> GetDeActive();
        T Find(Guid id);
        T GetByEntity(Func<T, bool> exp);

    }
}
