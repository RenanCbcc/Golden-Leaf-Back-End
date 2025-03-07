﻿using Golden_Leaf_Back_End.Models.ClerkModels;
using Golden_Leaf_Back_End.Models.ClientModels;
using System;
using System.Collections.Generic;

namespace Golden_Leaf_Back_End.Models.OrderModels
{
    public class Order : Base
    {
        public Order()
        {
            this.Items = new HashSet<Item>();
            this.Status = Status.Pendende;
        }

        public Client Client { get; set; }
        public ApplicationUser Clerk { get; set; }

        public DateTime Date { get; set; }

        public float Value { get; set; }
        public Status Status { get; set; }

        public HashSet<Item> Items { get; set; }

    }
}
