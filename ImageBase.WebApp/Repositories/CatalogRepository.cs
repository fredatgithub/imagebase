using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repositories
{
    public class CatalogRepository: ICatalogRepository
    {
        private AspPostgreSQLContext _context;

        public CatalogRepository(AspPostgreSQLContext context)
        {
            _context = context;
        }
        public void Add(Catalog obj)
        {
            _context.Catalogs.Add(obj);
        }

        public bool Delete(int id)
        {
            var obj = _context.Catalogs.Single(p => p.Id.CompareTo(id) == 0);
            if (obj is null)
            {
                return false;
            }
            _context.Catalogs.Remove(obj);

            return true;
        }

        public Catalog Get(int id)
        {
            return _context.Catalogs.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Catalog> GetAll()
        {
            return _context.Catalogs.AsEnumerable();
        }

        public IEnumerable<Catalog> GetSubCatalogs(int id)
        {
            return _context.Catalogs.Where(c => c.ParentCatalogId == id).AsEnumerable();
        }

        public Catalog Update(Catalog obj)
        {
            _context.Catalogs.Update(obj);
            return obj;
        }

        public void DeleteImageFromCatalog(ImageCatalog imageCatalog)
        {            
            _context.ImageCatalogs.Remove(imageCatalog);
        }

        public IQueryable<Image> GetImagesByCatalog(long id)
        {
            return _context.ImageCatalogs.Where(ic => ic.CatalogId == id)
                .Include(ic => ic.Image)
                .Select(i => i.Image);
        }

        public void AddImageToCatalog(ImageCatalog imageCatalog)
        {
            _context.ImageCatalogs.Add(imageCatalog);
        }

        public async Task<ImageCatalog> GetImageCatalogByIdFKAsync(long idImg, int idCat)
        {
            return await _context.ImageCatalogs.Where(ic => ic.ImageId == idImg && ic.CatalogId == idCat).FirstOrDefaultAsync();
        }
    }
}
