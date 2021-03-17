using Golden_Leaf_Back_End.Models.ProductModels;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class Item : Base
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public float Value { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is not Item item)
            {
                return false;
            }

            return this.ProductId == item.ProductId;
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }
    }
}
