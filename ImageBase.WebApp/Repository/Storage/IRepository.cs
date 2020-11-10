using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        void Add(T obj);
        T Update(T obj);
        bool Delete(long id);
    }
}
