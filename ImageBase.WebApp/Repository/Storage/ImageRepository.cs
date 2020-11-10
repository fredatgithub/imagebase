using ImageBase.WebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Repository.Storage
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(AspPostgreSQLContext context) : base(context)
        {
        }
        
        
    }
}
