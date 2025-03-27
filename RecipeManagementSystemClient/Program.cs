using System.Net.Http;
using System.Net.Http.Json;

Console.WriteLine("📡 Fetching most popular ingredients...\n");

string apiUrl = "https://localhost:7117/api/ingredientanalysis/popular"; // Replace PORT with correct API port

using HttpClient client = new HttpClient();

try
{
    var result = await client.GetFromJsonAsync<List<PopularIngredient>>(apiUrl);

    if (result != null && result.Count > 0)
    {
        Console.WriteLine("🍽️ Most Popular Ingredients:\n");
        foreach (var item in result)
        {
            Console.WriteLine($" - {item.Ingredient} (used {item.Count} times)");
        }
    }
    else
    {
        Console.WriteLine("⚠️ No data found from the API.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("❌ Error calling API:");
    Console.WriteLine(ex.Message);
}

public class PopularIngredient
{
    public string Ingredient { get; set; }
    public int Count { get; set; }
}
