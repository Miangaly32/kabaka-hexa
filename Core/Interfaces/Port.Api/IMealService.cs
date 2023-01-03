using Core.DTO.Meal;
using Core.Models;

namespace Core.Interfaces.Port.Api;

public interface IMealService
{
    Task<GetMealDto> AddAsync(AddMealDto meal);
    Task<List<GetMealDto>> GetAllAsync();
    Task<GetMealDto> GetByIdAsync(int id);
    Task<GetMealDto> UpdateAsync(UpdateMealDto meal);
    Task<List<IngredientQuantity>> GetIngredients(int mealId);
    Task DeleteAsync(int id);
}
