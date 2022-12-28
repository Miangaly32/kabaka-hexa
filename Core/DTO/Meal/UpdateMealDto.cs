using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Meal;

public class UpdateMealDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public List<int> IngredientsIds { get; set; }
    [Required]
    public string Description { get; set; }
}
