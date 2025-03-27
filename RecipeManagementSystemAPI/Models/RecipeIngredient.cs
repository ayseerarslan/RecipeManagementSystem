namespace IngredientAnalysisAPI.Models
{
    public class RecipeIngredient
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Quantity { get; set; }
    }
}
