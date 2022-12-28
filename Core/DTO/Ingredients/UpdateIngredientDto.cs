﻿using System.ComponentModel.DataAnnotations;

namespace Core.DTO.Ingredients;

public class UpdateIngredientDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int ColorId { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
