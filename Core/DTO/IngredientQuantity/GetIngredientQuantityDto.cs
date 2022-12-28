using Core.DTO.Ingredients;
using Core.DTO.Unit;

namespace Core.DTO.IngredientQuantity;

public class GetIngredientQuantityDto
{
    public GetIngredientDto Ingredient { get; set; }
    public int Quantity { get; set; }
    public GetUnitDto Unit { get; set; }
}
