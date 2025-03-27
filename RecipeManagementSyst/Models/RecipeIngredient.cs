using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagementSystem.Models
{
    public class RecipeIngredient
    {
        [Required]
        [ForeignKey("Recipe")]
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }

        [Required]
        [ForeignKey("Ingredient")]
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Quantity description cannot exceed 50 characters.")]
        public string Quantity { get; set; } // Example: "2 cups", "1 tbsp"
    }
}
