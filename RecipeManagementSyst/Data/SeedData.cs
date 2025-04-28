using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using RecipeManagementSystem.Data;
using RecipeManagementSyst.Models;
using System;
using System.Linq;

namespace RecipeManagementSyst.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RecipeDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<RecipeDbContext>>()))
            {
                // Check if DB already has data
                if (context.Recipes.Any() || context.Ingredients.Any())
                {
                    return; // DB has been seeded
                }

                // Add ingredients from IngredientController
                var ingredients = new Ingredient[]
                {
                    new Ingredient { Name = "Flour" },
                    new Ingredient { Name = "Eggs" },
                    new Ingredient { Name = "Milk" },
                    new Ingredient { Name = "Sugar" },
                    new Ingredient { Name = "Salt" },
                    new Ingredient { Name = "Butter" },
                    new Ingredient { Name = "Olive Oil" },
                    new Ingredient { Name = "Garlic" },
                    new Ingredient { Name = "Tomatoes" },
                    new Ingredient { Name = "Chicken Breast" }
                };

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();

                // Add recipes from RecipeController
                var recipes = new Recipe[]
                {
                    new Recipe { Name = "Pasta", Description = "A simple pasta dish", Instructions = "Boil water, add pasta, cook for 10 minutes, drain, add sauce" },
                    new Recipe { Name = "Chicken Curry", Description = "A spicy chicken curry", Instructions = "Fry onions, add chicken, add curry paste, simmer for 20 minutes" },
                    new Recipe { Name = "Chocolate Cake", Description = "A rich chocolate cake", Instructions = "Mix flour, sugar, cocoa, add eggs, bake for 30 minutes" },
                    new Recipe { Name = "Vegetable Stir-Fry", Description = "A quick and healthy stir-fry", Instructions = "Chop vegetables, stir-fry in oil, add soy sauce and garlic, cook for 5 minutes" },
                    new Recipe { Name = "Beef Stew", Description = "A hearty beef stew", Instructions = "Brown beef, add carrots and potatoes, pour in broth, simmer for 2 hours" },
                    new Recipe { Name = "Omelette", Description = "A simple egg omelette", Instructions = "Beat eggs, pour into pan, cook for 2 minutes, fold and serve" },
                    new Recipe { Name = "Caesar Salad", Description = "A classic Caesar salad", Instructions = "Chop lettuce, add croutons, mix with Caesar dressing, sprinkle cheese" },
                    new Recipe { Name = "Grilled Salmon", Description = "A delicious grilled salmon", Instructions = "Season salmon, grill for 6 minutes per side, serve with lemon" },
                    new Recipe { Name = "Mushroom Soup", Description = "A creamy mushroom soup", Instructions = "Sauté mushrooms, add broth, blend with cream, season to taste" },
                    new Recipe { Name = "Fruit Smoothie", Description = "A refreshing fruit smoothie", Instructions = "Blend banana, strawberries, yogurt, and honey until smooth" }
                };

                context.Recipes.AddRange(recipes);
                context.SaveChanges();

                // Add recipe-ingredient relationships
                var recipeIngredients = new RecipeIngredient[]
                {
                    // Pasta recipe ingredients
                    new RecipeIngredient { RecipeID = 1, IngredientID = 7, Quantity = "2 tbsp" }, // Olive Oil
                    new RecipeIngredient { RecipeID = 1, IngredientID = 8, Quantity = "2 cloves" }, // Garlic
                    new RecipeIngredient { RecipeID = 1, IngredientID = 9, Quantity = "3 medium" }, // Tomatoes
                    
                    // Chicken Curry recipe ingredients
                    new RecipeIngredient { RecipeID = 2, IngredientID = 7, Quantity = "3 tbsp" }, // Olive Oil
                    new RecipeIngredient { RecipeID = 2, IngredientID = 10, Quantity = "500g" }, // Chicken Breast
                    new RecipeIngredient { RecipeID = 2, IngredientID = 5, Quantity = "1 tsp" }, // Salt
                    
                    // Chocolate Cake recipe ingredients
                    new RecipeIngredient { RecipeID = 3, IngredientID = 1, Quantity = "2 cups" }, // Flour
                    new RecipeIngredient { RecipeID = 3, IngredientID = 2, Quantity = "3 large" }, // Eggs
                    new RecipeIngredient { RecipeID = 3, IngredientID = 4, Quantity = "1.5 cups" }, // Sugar
                    new RecipeIngredient { RecipeID = 3, IngredientID = 6, Quantity = "1/2 cup" }, // Butter
                    
                    // Add more recipe-ingredient relationships as needed
                };

                context.RecipeIngredients.AddRange(recipeIngredients);
                context.SaveChanges();
            }
        }
    }
}
