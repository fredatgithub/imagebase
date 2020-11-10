using AutoMapper;
using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using ImageBase.WebApp.Repository;
using ImageBase.WebApp.Repository.Storage;
using ImageBase.WebApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Service.Implementation
{
    public class ImageCatalogService: IImageCatalogService
    {
        private readonly IImageCatalogRepository _repository;
        private readonly AspPostgreSQLContext _context;
        private readonly IMapper _mapper;

        public ImageCatalogService(IImageCatalogRepository repository, AspPostgreSQLContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteImageFromCatalog(UpdateImageCatalogDto imageCatalogDto)
        {
            ImageCatalog imageCatalog = _repository.GetImageCatalogByIdFK(imageCatalogDto.ImageId, imageCatalogDto.CatalogId);
            var flag = _repository.Delete(imageCatalog.Id);
            if (flag)
                _context.SaveChanges();
            return flag;
        }

        public IEnumerable<ImageDto> GetImagesByIdCatalog(long id)
        {
            var catalog = _repository.GetCatalogWithImages(id);
            return _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDto>>(catalog.Select(c => c.Image));
        }

        public void AddImageToCatalog(UpdateImageCatalogDto imageCatalogDto)
        {
            ImageCatalog imageCatalog = new ImageCatalog()
            {
                ImageId = imageCatalogDto.ImageId,
                CatalogId = imageCatalogDto.CatalogId
            };
            _repository.Add(imageCatalog);
            _context.SaveChanges();
        }
    }
}
