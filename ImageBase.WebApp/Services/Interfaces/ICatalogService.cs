﻿using ImageBase.WebApp.Data.Dtos;
using ImageBase.WebApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDto>> GetCatalogsAsync();
        Task<CatalogDto> GetCatalogAsync(int id);
        Task<ServiceResponse<CatalogDto>> UpdateCatalogAsync(CatalogDto catalogDto);
        Task<bool> DeleteCatalogAsync(int id);
        Task<ServiceResponse<CatalogDto>> CreateCatalogAsync(CatalogDto catalogDto);
        Task<IEnumerable<CatalogDto>> GetSubCatalogsAsync(int id);
        Task AddImageToCatalogAsync(UpdateImageCatalogDto imageCatalogDto);
        Task<PaginationListDto<ImageDto>> GetImagesByCatalogAsync(int id, int offset, int limit);
        Task DeleteImageFromCatalogAsync(UpdateImageCatalogDto imageCatalogDto);
        Task<IEnumerable<CatalogDto>> GetCatalogsByUserAsync(string userId);
        Task<ServiceResponse<IEnumerable<CatalogDto>>> GetSubCatalogsByUserAsync(int parentId, string userId);
    }
}
