using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManagementSystem.Controllers
{
    public class RecipeController : Controller
    {
        private static List<Recipe> recipes = new List<Recipe>() // Temporary list before DB setup 
        {
            new Recipe { RecipeID = 1, Name = "Pasta", Description = "A simple pasta dish", Instructions = "Boil water, add pasta, cook for 10 minutes, drain, add sauce" },
            new Recipe { RecipeID = 2, Name = "Chicken Curry", Description = "A spicy chicken curry", Instructions = "Fry onions, add chicken, add curry paste, simmer for 20 minutes" },
            new Recipe { RecipeID = 3, Name = "Chocolate Cake", Description = "A rich chocolate cake", Instructions = "Mix flour, sugar, cocoa, add eggs, bake for 30 minutes" }
        };

        public IActionResult Index()
        {
            return View(recipes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipes.Add(recipe);
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        public IActionResult Edit(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeID == id);
            if (recipe == null)
                return NotFound();
            return View(recipe);
        }

        public IActionResult Details(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeID == id);
            if (recipe == null)
                return NotFound();

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(int id, Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var existingRecipe = recipes.FirstOrDefault(r => r.RecipeID == id);
                if (existingRecipe != null)
                {
                    existingRecipe.Name = recipe.Name;
                    existingRecipe.Description = recipe.Description;
                    existingRecipe.Instructions = recipe.Instructions;
                }
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        public IActionResult Delete(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeID == id);
            if (recipe == null)
                return NotFound();
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeID == id);
            if (recipe != null)
                recipes.Remove(recipe);
            return RedirectToAction("Index");
        }
    }
}
