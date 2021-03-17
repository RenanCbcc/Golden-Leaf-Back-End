using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.PaymentModels
{
    public class CreatingPaymentModel
    {
        public int ClientId { get; set; }

        [DataType(DataType.Currency)]
        public float Value { get; set; }
    }
}
