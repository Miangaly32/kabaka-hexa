using Core.DTO.Meal;

namespace Core.Interfaces.Port.Api;

public interface IMealHistoryService
{
    Task<GetMealDto> GetByDate(DateTime date);
    Task<List<GetMealDto>> GetByWeek(DateTime date);
    int Count();
}
