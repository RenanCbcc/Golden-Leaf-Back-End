using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.ClerkModels
{
    public class RegisterModel
    {

        [RegularExpression(@"^[\w\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\s]{5,50}$",
         ErrorMessage = "Nome do atendente é inválido.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [RegularExpression(@"^[1-9]{2}[1-9]{4,5}[0-9]{4}$",
         ErrorMessage = "Número de telefone inválido.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Senha e confirmação da senha precisam coincidir.")]
        public string ConfirmPassword { get; set; }
    }
}
