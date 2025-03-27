using Microsoft.AspNetCore.Mvc;
using RecipeManagementSystem.Models;

public class IngredientController : Controller
{
    private static List<Ingredient> ingredients = new List<Ingredient>
    {
        new Ingredient { IngredientID = 1, Name = "Flour" },
        new Ingredient { IngredientID = 2, Name = "Eggs" },
        new Ingredient { IngredientID = 3, Name = "Milk" },
    };

    public IActionResult Index() => View(ingredients);

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Ingredient ingredient)
    {
        if (ModelState.IsValid)
        {
            int newId = ingredients.Any() ? ingredients.Max(i => i.IngredientID) + 1 : 1;
            ingredient.IngredientID = newId;
            ingredients.Add(ingredient);
            return RedirectToAction("Index");
        }
        return View(ingredient);
    }

    public IActionResult Edit(int id)
    {
        var ingredient = ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
            return NotFound();
        return View(ingredient);
    }

    [HttpPost]
    public IActionResult Edit(int id, Ingredient ingredient)
    {
        if (ModelState.IsValid)
        {
            var existing = ingredients.FirstOrDefault(i => i.IngredientID == id);
            if (existing != null)
                existing.Name = ingredient.Name;

            return RedirectToAction("Index");
        }
        return View(ingredient);
    }

    public IActionResult Delete(int id)
    {
        var ingredient = ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
            return NotFound();
        return View(ingredient);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var ingredient = ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient != null)
            ingredients.Remove(ingredient);

        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var ingredient = ingredients.FirstOrDefault(i => i.IngredientID == id);
        if (ingredient == null)
            return NotFound();
        return View(ingredient);
    }
}
