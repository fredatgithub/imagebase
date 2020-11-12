using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;

namespace ImageBase.WebApp.Data.Dtos
{
    public class PaginationListDto<T> : List<T>
    {
        public PaginationListDto() { }
        public PaginationListDto(List<T> items)
        {
            this.AddRange(items);
        }

        public static async Task<PaginationListDto<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await GetItems(source, (pageIndex - 1) * pageSize, pageSize);

            return new PaginationListDto<T>(items);
        }
        public static async Task<List<T>> GetItems(IQueryable<T> source, int offset, int limit)
        {
            return await source.Skip(offset).Take(limit).ToListAsync();
        }
    }
}

