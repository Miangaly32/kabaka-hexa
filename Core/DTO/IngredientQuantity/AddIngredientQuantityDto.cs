using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.IngredientQuantity;

public class AddIngredientQuantityDto
{
    public int Quantity { get; set; }
    public int UnitId { get; set; }
    public int IngredientId { get; set; }
}
