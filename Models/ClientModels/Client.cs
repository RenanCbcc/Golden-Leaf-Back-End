using Golden_Leaf_Back_End.Models.OrderModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace Golden_Leaf_Back_End.Models.ClientModels
{
    public class Client : Base
    {
        public Client()
        {
            Status = Status.Ativo;
            Orders = new HashSet<Order>();
            Debt = 0;            
        }
        public ISet<Order> Orders { get; set; }

        public bool Notifiable { get; set; }

        public DateTime LastPurchase { get; set; }

        public float Debt { get; set; }

        [SwaggerSchema("Can be 'Inativo' or 'Ativo'.", Format = "enum")]
        public Status Status { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
