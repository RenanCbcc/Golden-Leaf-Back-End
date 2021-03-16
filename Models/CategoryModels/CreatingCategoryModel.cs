using System.ComponentModel.DataAnnotations;

namespace Golden_Leaf_Back_End.Models.CategoryModels
{
    public class CreatingCategoryModel
    {
        [Required(ErrorMessage = "Categoria deve ter um título.")]
        [StringLength(maximumLength: 50, MinimumLength = 5,
      ErrorMessage = "O título da categoria deve ter no mímino 5 caracteres e no máximo 50.")]
        public string Title { get; set; }
    }
}
