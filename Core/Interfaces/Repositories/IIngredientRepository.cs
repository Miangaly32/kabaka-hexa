using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IIngredientRepository
{
    Task<bool> CreateAsync(Ingredient ingredient);
    Task<List<Ingredient>> GetAllAsync();
    Task<Ingredient?> GetByIdAsync(int id);
    Task<Ingredient> UpdateAsync(Ingredient ingredient);

    Task DeleteAsync(int id);
}