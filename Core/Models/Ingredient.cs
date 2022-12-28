namespace Core.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ColorId { get; set; }
    public Color Color { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
