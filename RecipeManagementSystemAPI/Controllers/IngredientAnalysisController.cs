using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecipeManagementSystemAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientAnalysisController : ControllerBase
    {
        private readonly RecipeDbContext _context;
        private readonly ILogger<IngredientAnalysisController> _logger;

        public IngredientAnalysisController(RecipeDbContext context, ILogger<IngredientAnalysisController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/ingredientanalysis/popular
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularIngredients()
        {
            try
            {
                _logger.LogInformation("Getting popular ingredients");

                // First, check if we can access the database at all
                var ingredientCount = await _context.Ingredients.CountAsync();
                var recipeIngredientCount = await _context.RecipeIngredients.CountAsync();

                _logger.LogInformation($"Found {ingredientCount} ingredients and {recipeIngredientCount} recipe-ingredient relationships");

                if (recipeIngredientCount == 0)
                {
                    _logger.LogWarning("No recipe-ingredient relationships found in database");
                    return Ok(new object[0]); // Return empty array
                }

                // Simplify the query to troubleshoot
                var ingredients = await _context.Ingredients.ToListAsync();
                var recipeIngredients = await _context.RecipeIngredients.ToListAsync();

                _logger.LogInformation($"Loaded {ingredients.Count} ingredients and {recipeIngredients.Count} recipe-ingredient relationships");

                // Join the data in memory
                var result = recipeIngredients
                    .GroupBy(ri => ri.IngredientID)
                    .Select(group => new
                    {
                        Ingredient = ingredients.FirstOrDefault(i => i.IngredientID == group.Key)?.Name ?? "Unknown",
                        Count = group.Count()
                    })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                _logger.LogInformation($"Returning {result.Count} popular ingredients");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting popular ingredients");
                // Return the error details for debugging
                return StatusCode(500, new { error = ex.Message, stackTrace = ex.StackTrace });
            }
        }
    }
}
