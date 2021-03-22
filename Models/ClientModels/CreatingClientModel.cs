using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.ClientModels
{
    public class CreatingClientModel
    {
        [DataType(DataType.Text)]
        [RegularExpression(@"[\w\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\s]{5,50}$",
         ErrorMessage = "O nome do cliente deve ter no mímino 10 caracteres e no máximo 50 e conter somente letras.")]
        public string Name { get; set; }
        [Required]

        [RegularExpression(@"^[\w\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\s]{10,100}$", 
            ErrorMessage = "O endereço do cliente deve ter no mímino 10 caracteres e no máximo 100.")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]        
        [RegularExpression(@"^[1-9]{2}[1-9]{4,5}[0-9]{4}$/g", ErrorMessage = "O número de telefone deve ter exatamente 11 caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public bool Notifiable { get; set; }
    }
}
