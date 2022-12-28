using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IMealRepository
{
    Task<bool> CreateAsync(Meal meal);
    Task<List<Meal>> GetAllAsync();
    Task<Meal> GetByIdAsync(int id);
    Task<Meal> UpdateAsync(Meal meal);

    Task DeleteAsync(int id);
}
