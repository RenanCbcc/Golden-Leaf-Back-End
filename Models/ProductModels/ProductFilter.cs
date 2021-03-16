using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.ProductModels
{
    public static class ProductFilterExtentions
    {
        public static IQueryable<Product> AplyFilter(this IQueryable<Product> query, ProductFilter filter)
        {
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Description))
                {
                    query = query.Where(p => p.Description.Contains(filter.Description));
                }

                if (filter.QuantityBiggerThan != 0)
                {
                    query = query.Where(p => filter.QuantityBiggerThan > p.Quantity);
                }

                if (filter.QuantityLessThan != 0)
                {
                    query = query.Where(p => filter.QuantityLessThan < p.Quantity);
                }

                if (filter.RunningLow)
                {
                    query = query.Where(p => p.Quantity < p.MinimumQuantity);
                }
            }
            return query;
        }

    }
    public class ProductFilter
    {
        public string Description { get; set; }
        public int QuantityBiggerThan { get; set; }
        public int QuantityLessThan { get; set; }
        public bool RunningLow { get; set; } = false;
    }
}
