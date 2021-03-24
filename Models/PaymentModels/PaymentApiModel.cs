using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models.PaymentModels
{
    public class PaymentApiModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClerkId { get; set; }

        public string ClerkName { get; set; }

        public float Amount { get; set; }

        public DateTime Date { get; set; }

    }
}
