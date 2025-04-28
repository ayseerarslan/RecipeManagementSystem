using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagementSystemAPI.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
