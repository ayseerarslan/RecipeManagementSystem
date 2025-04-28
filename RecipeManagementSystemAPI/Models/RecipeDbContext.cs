using Microsoft.EntityFrameworkCore;

namespace RecipeManagementSystemAPI.Models
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeID, ri.IngredientID });

            // Configure one-to-many relationship between Recipe and RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeID);

            // Configure one-to-many relationship between Ingredient and RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientID);

            // Specify exact table names to match main application
            modelBuilder.Entity<Recipe>().ToTable("Recipes");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<RecipeIngredient>().ToTable("RecipeIngredients");
        }
    }
}
