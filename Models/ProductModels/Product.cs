using Golden_Leaf_Back_End.Models.CategoryModels;

namespace Golden_Leaf_Back_End.Models.ProductModels
{
    public class Product : Base
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public float PurchasePrice { get; set; }

        public float SalePrice { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public int MinimumQuantity { get; set; }

    }
}
