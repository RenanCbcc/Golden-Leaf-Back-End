using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models
{
    public static class EntityPaginationExtentions
    {
        public static async Task<Pagination<T>> ToEntityPaginated<T>(this IQueryable<T> query, PagingParams pagination)
        {
            int count = query.Count();
            int totalPages = (int)Math.Ceiling(count / (double)pagination.PageSize);
            string endPoint = typeof(T).Name.ToLower();
            return new Pagination<T>()
            {
                Total = count,
                Pages = totalPages,
                Page = pagination.Page,
                Size = pagination.PageSize,
                Data = await query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync(),
                Previous = (pagination.Page > 1) ?
                $"{endPoint}?size={pagination.PageSize}&page={pagination.Page - 1}" : "",
                Next = (pagination.Page < totalPages) ?
                $"{endPoint}?size={pagination.PageSize}&page={pagination.Page + 1}" : ""
            };

        }
    }
    public class Pagination<T>
    {

        public int Total { get; set; }
        public int Pages { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public List<T> Data { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
