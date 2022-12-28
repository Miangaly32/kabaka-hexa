using Core.DTO.IngredientQuantity;

namespace Core.DTO.Meal;

public class GetMealDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
