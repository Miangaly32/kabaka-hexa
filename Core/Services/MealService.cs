using Core.DTO.Meal;
using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;

public class MealService : IMealService
{
    private readonly IMealRepository _repository;

    public MealService(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetMealDto> AddAsync(AddMealDto request)
    {
        var meal = Mapping.Mapper.Map<Meal>(request);
        await _repository.CreateAsync(meal);

        return Mapping.Mapper.Map<GetMealDto>(meal);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<GetMealDto>> GetAllAsync()
    {
        var meals = await _repository.GetAllAsync();
        return meals.Select(meal => Mapping.Mapper.Map<GetMealDto>(meal)).ToList();
    }

    public async Task<GetMealDto> GetByIdAsync(int id)
    {
        var meal = await _repository.GetByIdAsync(id);
        if (meal == null)
            throw new Exception("Ingredient not found");

        return Mapping.Mapper.Map<GetMealDto>(meal);
    }

    public async Task<List<IngredientQuantity>> GetIngredients(int mealId)
    {
        return await _repository.GetIngredientsAsync(mealId);
    }

    public async Task<GetMealDto> UpdateAsync(UpdateMealDto request)
    {
        var meal = await _repository.UpdateAsync(Mapping.Mapper.Map<Meal>(request));

        return Mapping.Mapper.Map<GetMealDto>(meal);
    }
}
