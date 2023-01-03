using Core.DTO.Meal;
using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;

public class MealHistoryService : IMealHistoryService
{
    private readonly IMealHistoryRepository _repository;
    private readonly IMealService _mealService;
    public MealHistoryService(IMealHistoryRepository mealHistoryRepository, IMealService mealService)
    {
        _repository = mealHistoryRepository;
        _mealService = mealService;
    }

    public int Count()
    {
        return _repository.Count();
    }

    public async Task<GetMealDto> GetByDate(DateTime date)
    {
        var meals = await _mealService.GetAllAsync();
        var history = new MealHistory();
        var mealOfTheDay = meals.First();
        
        var mealYesterday = await _repository.GetByDay(date.AddDays(-1));
        if (mealYesterday != null)
        {
            //appliquer les regles par rapport a hier
            var ingredientQuantities = await _mealService.GetIngredients(mealYesterday.MealId);

            // pas les memes ingredients
            // color
            // category : viande, poisson, fruit de mer, volaille
            throw new Exception("Insufficient data");
        }

        history.Meal = Mapping.Mapper.Map<Meal>(mealOfTheDay);
        history.Date = date;
        try
        {
            await _repository.AddAsync(history);
            return Mapping.Mapper.Map<GetMealDto>(mealOfTheDay);
        }
        catch
        {
            throw;
        }
    }

    public Task<List<GetMealDto>> GetByWeek(DateTime date)
    {
        throw new NotImplementedException();
    }
}
