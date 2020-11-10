using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public class Repository<T>: IRepository<T> where T: BaseEntity
    {
        protected readonly DbSet<T> _entity;
        public Repository(AspPostgreSQLContext context)
        {
            _entity = context.Set<T>();
        }

        public void Add(T obj)
        {
            _entity.Add(obj);
        }

        public T Get(long id)
        {
            return _entity.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T obj)
        {
            _entity.Update(obj);
            return obj;
        }
        public bool Delete(long id)
        {
            var obj = _entity.Single(p => p.Id == id);
            if (obj is null)
            {
                return false;
            }

            _entity.Remove(obj);

            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }
    }
}
