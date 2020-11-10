using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Dtos
{
    public class AddImageDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<long> CatalogsId { get; set; }
        public List<long> KeyWordsId { get; set; }
    }
}
