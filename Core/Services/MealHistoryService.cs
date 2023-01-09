using Core.DTO.Meal;
using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;

public class MealHistoryService : IMealHistoryService
{
    private readonly IMealHistoryRepository _repository;
    private readonly IMealRepository _mealRepository;
    public MealHistoryService(IMealHistoryRepository mealHistoryRepository, IMealRepository mealRepository)
    {
        _repository = mealHistoryRepository;
        _mealRepository = mealRepository;
    }

    public int Count()
    {
        return _repository.Count();
    }

    public async Task<GetMealDto> GetByDate(DateTime date)
    {
        var mealHistoryOfTheDay = await _repository.GetHistoryByDate(date.Date);

        if (mealHistoryOfTheDay != null)
        {
            return Mapping.Mapper.Map<GetMealDto>(mealHistoryOfTheDay.Meal);
        }
            
        if (_mealRepository.Count() == 0 )
        {
            throw new Exception("Insufficient data");
        }

        var mealOfTheDay = await _mealRepository.GetOneAsync();

        var historyEmpty = _repository.Count() == 0;
        if (!historyEmpty)
        {
            mealOfTheDay = await _mealRepository.getMealApplyingRules(date);
        }

        var history = new MealHistory();
        history.Date = date.Date;
        history.MealId = mealOfTheDay.Id;
        await _repository.AddAsync(history);
       
        return Mapping.Mapper.Map<GetMealDto>(mealOfTheDay);
    }

    public Task<List<GetMealDto>> GetByWeek(DateTime date)
    {
        throw new NotImplementedException();
    }
}
