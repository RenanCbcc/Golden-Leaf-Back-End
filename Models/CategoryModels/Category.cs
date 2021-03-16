using Golden_Leaf_Back_End.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.CategoryModels
{
    public class Category : Base
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string Title { get; set; }

        public ISet<Product> Products { get; set; }
    }
}
