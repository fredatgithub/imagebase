using ImageBase.WebApp.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Service.Interface
{
    public interface IImageCatalogService
    {
        IEnumerable<ImageDto> GetImagesByIdCatalog(long id);
        void AddImageToCatalog(UpdateImageCatalogDto imageCatalog);
        bool DeleteImageFromCatalog(UpdateImageCatalogDto imageCatalog);
    }
}
