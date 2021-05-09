using System;

namespace Golden_Leaf_Back_End.Models.AccountModels
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime Expires { get; set; }
    }
}
