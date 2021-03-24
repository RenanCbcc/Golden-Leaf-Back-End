using System;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class OrderApiModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClerkId { get; set; }

        public string ClerkName { get; set; }

        public float Value { get; set; }

        public Status Status { get; set; }

        public DateTime Date { get; set; }

    }
}
