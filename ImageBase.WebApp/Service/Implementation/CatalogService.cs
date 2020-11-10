using AutoMapper;
using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using ImageBase.WebApp.Repository;
using ImageBase.WebApp.Repository.Storage;
using ImageBase.WebApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Service.Implementation
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

        public void CreateCatalog(CatalogDto catalogDto)
        {
            Catalog catalog = _mapper.Map<Catalog>(catalogDto);
            _repository.Add(catalog);
            _context.SaveChanges();
        }

        public bool DeleteCatalog(long id)
        {
            bool flag = _repository.Delete(id);
            if (flag)
                _context.SaveChanges();
            return flag;           
        }

        public CatalogDto GetCatalog(long id)
        {
            CatalogDto catalogDto = _mapper.Map<CatalogDto>(_repository.Get(id));
            return catalogDto;
        }

        public IEnumerable<CatalogDto> GetCatalogs()
        {
            var catalogsDto = _mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDto>>(_repository.GetAll());
            return catalogsDto;
        }

        public IEnumerable<CatalogDto> GetSubCatalogs(long id)
        {
            var catalogsDto = _mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDto>>(_repository.GetSubCatalogs(id));
            return catalogsDto;
        }

        public CatalogDto UpdateCatalog(long id, CatalogDto catalogDto)
        {
            Catalog catalog = _mapper.Map<Catalog>(catalogDto);
            catalog.Id = id;
            _repository.Update(catalog);
            _context.SaveChanges();
            return catalogDto;
        }
    }
}
