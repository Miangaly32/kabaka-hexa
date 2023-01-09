using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IMealHistoryRepository
{
    Task<bool> AddAsync(MealHistory meal);
    Task<MealHistory?> GetHistoryByDate(DateTime date);
    Task<List<MealHistory>> GetAll();
    Task<MealHistory> GetLast(DateTime date);
    int Count();
}
