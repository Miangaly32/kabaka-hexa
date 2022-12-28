namespace Core.Models;

public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IngredientQuantity> Ingredients { get; set;}
    public string Description { get; set; }
}

