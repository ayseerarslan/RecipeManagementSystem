using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagementSystemAPI.Models
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
        [StringLength(50)]
        public string Quantity { get; set; }
    }
}
