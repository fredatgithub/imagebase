using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Dtos
{
    public class CatalogDto
    {
        public string Name { get; set; }
        public long? ParentCatalogId { get; set; }
        public string UserId { get; set; }   
    }
}
