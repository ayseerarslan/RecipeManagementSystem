using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RecipeManagementSystemAPI.Models;
using System;
using System.Linq;

namespace RecipeManagementSystemAPI
{
    public static class DbSeeder
    {
        public static IHost SeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<RecipeDbContext>();
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogInformation("Checking database for existing data");
                    // In your DbSeeder.cs, add more detailed logging
                    logger.LogInformation($"Connection string: {context.Database.GetConnectionString()}");
                    logger.LogInformation($"Database provider: {context.Database.ProviderName}");


                    // Only seed if the RecipeIngredients table is empty
                    if (!context.RecipeIngredients.Any())
                    {
                        logger.LogInformation("No recipe ingredients found. Seeding data...");

                        // Get existing recipes and ingredients or create new ones if needed
                        var recipes = context.Recipes.ToList();
                        var ingredients = context.Ingredients.ToList();

                        if (!recipes.Any())
                        {
                            logger.LogInformation("No recipes found. Adding sample recipes...");
                            recipes.Add(new Recipe { Name = "Pasta", Description = "Simple pasta dish", Instructions = "Boil pasta, add sauce" });
                            recipes.Add(new Recipe { Name = "Chocolate Cake", Description = "Delicious dessert", Instructions = "Mix ingredients, bake at 350F" });
                            context.Recipes.AddRange(recipes);
                            context.SaveChanges();
                            // Reload recipes with IDs
                            recipes = context.Recipes.ToList();
                        }

                        if (!ingredients.Any())
                        {
                            logger.LogInformation("No ingredients found. Adding sample ingredients...");
                            ingredients.Add(new Ingredient { Name = "Flour" });
                            ingredients.Add(new Ingredient { Name = "Sugar" });
                            ingredients.Add(new Ingredient { Name = "Pasta" });
                            ingredients.Add(new Ingredient { Name = "Tomato Sauce" });
                            context.Ingredients.AddRange(ingredients);
                            context.SaveChanges();
                            // Reload ingredients with IDs
                            ingredients = context.Ingredients.ToList();
                        }

                        logger.LogInformation("Adding recipe-ingredient relationships...");
                        // Add recipe-ingredient relationships
                        context.RecipeIngredients.AddRange(
                            new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity = "500g" },
                            new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity = "1 jar" },
                            new RecipeIngredient { RecipeID = recipes[1].RecipeID, IngredientID = ingredients[0].IngredientID, Quantity = "2 cups" },
                            new RecipeIngredient { RecipeID = recipes[1].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity = "1 cup" }
                        );

                        context.SaveChanges();
                        logger.LogInformation("Database seeding completed successfully");
                    }
                    else
                    {
                        logger.LogInformation("Database already contains recipe ingredients. Skipping seeding.");
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            return host;
        }
    }
}
