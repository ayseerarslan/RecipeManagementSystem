using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagementSyst.Models
{
    public class Ingredient
    {
        [Key]
        [DisplayName("Ingredient ID:")]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [DisplayName("Name:")]
        public string Name { get; set; }

        // Navigation property
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
