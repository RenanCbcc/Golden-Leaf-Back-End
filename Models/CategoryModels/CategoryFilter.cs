﻿using System.Linq;
namespace Golden_Leaf_Back_End.Models.CategoryModels
{
    public static class CategoryFilterExtentions
    {
        public static IQueryable<Category> AplyFilter(this IQueryable<Category> query, CategoryFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    query = query.Where(c => c.Title.ToLower().Contains(filter.Title.ToLower()));
                }

            }
            return query;
        }

    }
    public class CategoryFilter
    {
        public string Title { get; set; }
    }
}
