using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public class ImageCatalogRepository : Repository<ImageCatalog>, IImageCatalogRepository
    {
        public ImageCatalogRepository(AspPostgreSQLContext context) : base(context)
        {
        }

        public ImageCatalog GetImageCatalogByIdFK(long idImg, long idCat)
        {
            return _entity.Where(ic => ic.ImageId == idImg && ic.CatalogId == idCat).FirstOrDefault();
        }
        public IEnumerable<ImageCatalog> GetCatalogWithImages(long id)
        {
            return _entity.Where(ic => ic.CatalogId == id).Include(ic => ic.Image).AsEnumerable();
        }
        
    }
}
