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
    Task<GetIngredientDto> AddAsync(AddIngredientDto request);
    Task<List<GetIngredientDto>> GetAllAsync();
    Task<GetIngredientDto> GetByIdAsync(int id);
    Task<GetIngredientDto> UpdateAsync(UpdateIngredientDto ingredient);
    Task DeleteAsync(int id);
}
