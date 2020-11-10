using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public class CatalogRepository: Repository<Catalog>, ICatalogRepository 
    {
        public CatalogRepository(AspPostgreSQLContext context): base (context)
        { }

        public IEnumerable<Catalog> GetSubCatalogs(long id)
        {
            return _entity.Where(c => c.ParentCatalogId == id).AsEnumerable();
        }
    }
}
