﻿using Golden_Leaf_Back_End.Models.ClientModels;
using System;

namespace Golden_Leaf_Back_End.Models.PaymentModels
{
    public class Payment : Base
    {
        public Client Client { get; set; }

        public DateTime Date { get; set; }

        public float Amount { get; set; }
    }
}
