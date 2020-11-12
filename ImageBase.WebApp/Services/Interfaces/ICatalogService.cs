using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Services.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<CatalogDto> GetCatalogs();
        CatalogDto GetCatalog(int id);
        Task<CatalogDto> UpdateCatalogAsync(int id, CatalogDto catalogDto);
        IEnumerable<CatalogDto> GetSubCatalogs(int id);
        Task<bool> DeleteCatalogAsync(int id);
        Task CreateCatalogAsync(CatalogDto catalogDto);
        Task AddImageToCatalogAsync(UpdateImageCatalogDto imageCatalogDto);
        Task<IEnumerable<ImageDto>> GetImagesByCatalogAsync(int id);
        Task<IEnumerable<ImageDto>> GetImagesByCatalogAsync(int id, int offset, int limit);
        Task DeleteImageFromCatalogAsync(UpdateImageCatalogDto imageCatalogDto);
    }
}
