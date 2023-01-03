using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Ingredients;

public class AddIngredientDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int ColorId { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
