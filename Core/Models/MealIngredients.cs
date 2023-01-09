namespace Core.Models;

public class MealIngredients
{
    public int MealId { get; set; }
    public int IngredientId { get; set; }
    public string Ingredient { get; set; }
    public int ColorId { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public string Symbol { get; set; }
}
