using System;

namespace Golden_Leaf_Back_End.Models.AccountModels
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public Token Token { get; set; }

    }
}
