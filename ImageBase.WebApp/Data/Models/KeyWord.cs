using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Models
{
    public class KeyWord: BaseEntity
    {
        public string Key { get; set; }
        public List<ImageKeyWord> ImageKeyWords { get; set; }
    }
}
