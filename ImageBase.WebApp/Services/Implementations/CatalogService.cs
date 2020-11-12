using AutoMapper;
using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using ImageBase.WebApp.Repositories;
using ImageBase.WebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;
        private readonly AspPostgreSQLContext _context;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository repository, AspPostgreSQLContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCatalogAsync(CatalogDto catalogDto)
        {
            Catalog catalog = _mapper.Map<Catalog>(catalogDto);
            _repository.Add(catalog);
            await _context.SaveChangesAsync();
        }
        
        public async Task<bool> DeleteCatalogAsync(int id)
        {
            bool flag = _repository.Delete(id);
            if (flag)
                await _context.SaveChangesAsync();
            return flag;           
        }

        public CatalogDto GetCatalog(int id)
        {
            CatalogDto catalogDto = _mapper.Map<CatalogDto>(_repository.Get(id));
            return catalogDto;
        }

        public IEnumerable<CatalogDto> GetCatalogs()
        {
            var catalogsDto = _mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDto>>(_repository.GetAll());
            return catalogsDto;
        }

        public IEnumerable<CatalogDto> GetSubCatalogs(int id)
        {
            var catalogsDto = _mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDto>>(_repository.GetSubCatalogs(id));
            return catalogsDto;
        }

        public async Task<CatalogDto> UpdateCatalogAsync(int id, CatalogDto catalogDto)
        {
            Catalog catalog = _mapper.Map<Catalog>(catalogDto);
            catalog.Id = id;
            _repository.Update(catalog);
            await _context.SaveChangesAsync();
            return catalogDto;
        }

        public async Task DeleteImageFromCatalogAsync(UpdateImageCatalogDto imageCatalogDto)
        {
            ImageCatalog imageCatalog = await _repository.GetImageCatalogByIdFKAsync(imageCatalogDto.ImageId, imageCatalogDto.CatalogId);
            _repository.DeleteImageFromCatalog(imageCatalog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageDto>> GetImagesByCatalogAsync(int id)
        {
            var catalog = _repository.GetImagesByCatalog(id);
            return _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDto>>(await catalog.ToListAsync());
        }

        public async Task<IEnumerable<ImageDto>> GetImagesByCatalogAsync(int id, int offset, int limit)
        {
            var imagesQuery = _repository.GetImagesByCatalog(id);
            var list = await PaginationListDto<Image>.GetItems(imagesQuery.OrderBy(i => i.Id), offset, limit);

            var imageDtos = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDto>>(list);

            return imageDtos;
        }

        public async Task AddImageToCatalogAsync(UpdateImageCatalogDto imageCatalogDto)
        {
            ImageCatalog imageCatalog = new ImageCatalog()
            {
                ImageId = imageCatalogDto.ImageId,
                CatalogId = imageCatalogDto.CatalogId
            };
            _repository.AddImageToCatalog(imageCatalog);
            await _context.SaveChangesAsync();
        }
    }
}
