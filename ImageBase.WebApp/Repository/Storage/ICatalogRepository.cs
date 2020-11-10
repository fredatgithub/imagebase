using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public interface ICatalogRepository: IRepository<Catalog>
    {
        IEnumerable<Catalog> GetSubCatalogs(long id);

    }
}
