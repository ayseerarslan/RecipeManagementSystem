using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using IngredientAnalysisAPI.Models;

namespace IngredientAnalysisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientAnalysisController : ControllerBase
    {

        private static List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>
        {
            new RecipeIngredient { RecipeID = 1, IngredientID = 1, Quantity = "2 cups" }, // Flour
            new RecipeIngredient { RecipeID = 1, IngredientID = 2, Quantity = "2" },     // Eggs
            new RecipeIngredient { RecipeID = 2, IngredientID = 2, Quantity = "3" },     // Eggs
            new RecipeIngredient { RecipeID = 2, IngredientID = 3, Quantity = "1 cup" }, // Milk
            new RecipeIngredient { RecipeID = 3, IngredientID = 1, Quantity = "1.5 cups" } // Flour
        };

        private static List<Ingredient> ingredients = new List<Ingredient>
        {
            new Ingredient { IngredientID = 1, Name = "Flour" },
            new Ingredient { IngredientID = 2, Name = "Eggs" },
            new Ingredient { IngredientID = 3, Name = "Milk" }
        };

        // GET: api/ingredientanalysis/popular
        [HttpGet("popular")]
        public IActionResult GetPopularIngredients()
        {
            var popularity = recipeIngredients
                .GroupBy(ri => ri.IngredientID)
                .Select(group => new
                {
                    Ingredient = ingredients.First(i => i.IngredientID == group.Key).Name,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            return Ok(popularity);
        }
    }
}
