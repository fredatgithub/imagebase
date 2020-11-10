using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Models
{
    public class ImageCatalog: BaseEntity
    {
        public long ImageId { get; set; }
        public Image Image { get; set; }
        public long CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
