using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public interface IImageCatalogRepository: IRepository<ImageCatalog>
    {
        ImageCatalog GetImageCatalogByIdFK(long idImg, long idCat);
        IEnumerable<ImageCatalog> GetCatalogWithImages(long id);
    }
}
