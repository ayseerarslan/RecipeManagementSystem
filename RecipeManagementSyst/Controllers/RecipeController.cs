using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeManagementSyst.Data;
using RecipeManagementSyst.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagementSyst.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeDbContext _context;

        public RecipeController(RecipeDbContext context)
        {
            _context = context;
        }

        // GET: Recipe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Instructions")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,Name,Description,Instructions")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                // First, delete any associated RecipeIngredients
                var recipeIngredients = await _context.RecipeIngredients
                    .Where(ri => ri.RecipeID == id)
                    .ToListAsync();
                
                _context.RecipeIngredients.RemoveRange(recipeIngredients);
                
                // Then delete the recipe
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }
    }
}
