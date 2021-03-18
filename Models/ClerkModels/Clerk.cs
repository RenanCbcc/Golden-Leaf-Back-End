using Golden_Leaf_Back_End.Models.OrderModels;
using Golden_Leaf_Back_End.Models.PaymentModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Golden_Leaf_Back_End.Models.ClerkModels
{
    public class Clerk : IdentityUser
    {
        public Clerk()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        public string Photo { get; set; }
        public ISet<Order> Orders { get; set; }
        public ISet<Payment> Payments { get; set; }
    }
}
