using Core.DTO.Ingredients;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Port.Api;

public interface IIngredientService
{
    Task<Ingredient> AddAsync(IngredientRequest request);
    Task<List<IngredientResponse>> GetAllAsync();
    Task<IngredientResponse> GetByIdAsync(int id);
    Task<Ingredient> UpdateAsync(IngredientRequest ingredient);
    Task DeleteAsync(int id);
}
