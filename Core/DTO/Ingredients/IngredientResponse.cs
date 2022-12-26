using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Ingredients;

public class IngredientResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public Category Category { get; set; }
}
