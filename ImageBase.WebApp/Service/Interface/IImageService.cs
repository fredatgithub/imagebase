using ImageBase.WebApp.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Service.Interface
{
    public interface IImageService
    {
        void CreateImage(AddImageDto imageDto);
    }
}
