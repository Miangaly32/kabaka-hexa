using Core.Models;

namespace Core.DTO.Ingredients;

public class GetIngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Color Color { get; set; }
    public Category Category { get; set; }
}
