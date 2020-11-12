using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repositories
{
    public interface IRepository<T, TId> 
    {
        T Get(TId id);
        IEnumerable<T> GetAll();
        void Add(T obj);
        T Update(T obj);
        bool Delete(TId id);
    }
}
