using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientAnalysisController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public IngredientAnalysisController(RecipeDbContext context)
        {
            _context = context;
        }

        // GET: api/ingredientanalysis/popular
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularIngredients()
        {
            var popularity = await _context.RecipeIngredients
                .Include(ri => ri.Ingredient)
                .GroupBy(ri => ri.IngredientID)
                .Select(group => new
                {
                    Ingredient = group.First().Ingredient.Name,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            return Ok(popularity);
        }
    }
}
