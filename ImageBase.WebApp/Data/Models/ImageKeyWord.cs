using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Models
{
    public class ImageKeyWord: BaseEntity
    {
        public long ImageId {get; set;}
        public Image Image { get; set; }
        public long KeyWordId { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
