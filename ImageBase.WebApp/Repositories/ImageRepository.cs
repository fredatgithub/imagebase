using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private AspPostgreSQLContext _context;
        public ImageRepository(AspPostgreSQLContext context)
        {
            _context = context;
        }

        public void Add(Image obj)
        {
            _context.Images.Add(obj);
        }

        public bool Delete(long id)
        {
            var obj = _context.Images.Single(p => p.Id.CompareTo(id) == 0);
            if (obj is null)
            {
                return false;
            }
            _context.Images.Remove(obj);

            return true;
        }

        public Image Get(long id)
        {
            return _context.Images.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Images.AsEnumerable();
        }

        public Image Update(Image obj)
        {
            _context.Images.Update(obj);
            return obj;
        }
    }
}
