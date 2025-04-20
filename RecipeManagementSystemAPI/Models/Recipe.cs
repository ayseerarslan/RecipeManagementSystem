using System.Collections.Generic;

namespace RecipeManagementSystemAPI.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
