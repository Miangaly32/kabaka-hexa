using Core.DTO.IngredientQuantity;
using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Meal;

public class AddMealDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public List<AddIngredientQuantityDto> Ingredients { get; set; }
    [Required]
    public string Description { get; set; }
}
