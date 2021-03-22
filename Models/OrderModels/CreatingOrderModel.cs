using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class CreatingOrderModel
    {
        public CreatingOrderModel()
        {
            Items = new HashSet<Item>();
        }

        public int ClientId { get; set; }
        public int ClerkId { get; set; }

        [Required]
        public HashSet<Item> Items { get; set; }
    }
}
