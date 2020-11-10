using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Models
{
    public class Image: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ImageKeyWord> ImageKeyWords { get; set; }
        public List<ImageCatalog> ImageCatalogs { get; set; }
    }
}
