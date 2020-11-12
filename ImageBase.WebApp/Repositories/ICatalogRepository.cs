using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repositories
{
    public interface ICatalogRepository: IRepository<Catalog, int>
    {
        IEnumerable<Catalog> GetSubCatalogs(int id);
        IQueryable<Image> GetImagesByCatalog(long id);
        void AddImageToCatalog(ImageCatalog imageCatalog);
        void DeleteImageFromCatalog(ImageCatalog imageCatalog);
        Task<ImageCatalog> GetImageCatalogByIdFKAsync(long idImg, int idCat);
    }
}
