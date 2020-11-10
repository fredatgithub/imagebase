using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Service.Interface
{
    public interface ICatalogService
    {
        IEnumerable<CatalogDto> GetCatalogs();
        CatalogDto GetCatalog(long id);
        void CreateCatalog(CatalogDto catalogDto);
        CatalogDto UpdateCatalog(long id, CatalogDto catalogDto);
        bool DeleteCatalog(long id);
        IEnumerable<CatalogDto> GetSubCatalogs(long id);
        
    }
}
