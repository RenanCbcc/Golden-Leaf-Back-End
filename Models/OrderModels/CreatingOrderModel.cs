using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class CreatingOrderModel
    {
        public CreatingOrderModel()
        {
            Items = new HashSet<Item>();
        }

        public int CLientId { get; set; }

        [Required]
        public HashSet<Item> Items { get; set; }
    }
}
