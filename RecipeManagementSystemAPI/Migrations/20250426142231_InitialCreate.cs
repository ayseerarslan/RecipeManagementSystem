using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientID",
                table: "RecipeIngredients",
                column: "IngredientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
