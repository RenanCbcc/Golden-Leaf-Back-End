using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.CategoryModels
{
    public class CreatingCategoryModel
    {

        [RegularExpression(@"^[A-Za-z\u00C0-\u00D6\u00D8-\u00f6\u00f8-\u00ff\s]{5,50}$",
         ErrorMessage = "O título da categoria deve ter no mímino 5 caracteres e no máximo 50 e conter somente letras.")]
        public string Title { get; set; }
    }
}
