using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Ingredients;

public class IngredientRequest
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
