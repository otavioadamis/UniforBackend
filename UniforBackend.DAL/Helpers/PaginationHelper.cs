using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniforBackend.Domain.Models.DTOs.PageTOs;

namespace UniforBackend.DAL.Helpers
{
    public class PaginationHelper
    {
        public static PagedResult<T> Paginate<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalItems = query.Count();
            var pageCount = (int)Math.Ceiling(totalItems / (float)pageSize);

            var items = query.Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PagedResult<T>
            {
                Items = items,
                PageAtual = pageNumber,
                Pages = pageCount,
            };
        }
    }
}
