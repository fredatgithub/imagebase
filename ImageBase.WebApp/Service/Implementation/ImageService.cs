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
    public class ImageService: IImageService
    {
        private readonly IImageRepository _repository;
        private readonly AspPostgreSQLContext _context;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository repository, AspPostgreSQLContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }
        public void CreateImage(AddImageDto imageDto)
        {
            Image image = _mapper.Map<Image>(imageDto);
            _repository.Add(image);
            _context.SaveChanges();
        }
    }
}
