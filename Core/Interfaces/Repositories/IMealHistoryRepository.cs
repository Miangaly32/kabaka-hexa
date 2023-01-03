using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IMealHistoryRepository
{
    Task<bool> AddAsync(MealHistory meal);
    Task<MealHistory> GetByDay(DateTime date);
    Task<List<MealHistory>> GetAll();
    int Count();
}
