using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IMealRepository
{
    Task<bool> CreateAsync(Meal meal);
    Task<List<Meal>> GetAllAsync();
    Task<Meal?> GetByIdAsync(int id);
    Task<Meal> GetOneAsync();
    Task<Meal> UpdateAsync(Meal meal);
    Task<List<MealIngredients>> GetIngredientsAsync(int mealId);
    Task DeleteAsync(int id);
    int Count();
    Task<Meal> getMealApplyingRules(DateTime date);
}
