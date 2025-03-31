using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagementSystem.Models
{
    public class Recipe
    {
        [Key]
        [DisplayName("Recipe ID:")]
        public int RecipeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Cook Time (In Minutes):")]
        public int CookTime { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [DisplayName("Description:")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Instructions:")]
        public string Instructions { get; set; }

        // Navigation property
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}
