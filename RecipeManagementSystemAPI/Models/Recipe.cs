using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagementSystemAPI.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string Instructions { get; set; }

        // Navigation property
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
