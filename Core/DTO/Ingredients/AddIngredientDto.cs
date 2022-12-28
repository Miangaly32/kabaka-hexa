using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
