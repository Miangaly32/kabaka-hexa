using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class MealRepository : IMealRepository
{
    private readonly AppDbContext context;
    private readonly IMealHistoryRepository _historyRepository;

    public MealRepository(AppDbContext appDbContext, IMealHistoryRepository historyRepository)
    {
        context = appDbContext;
        _historyRepository = historyRepository;
    }

    public int Count()
    {
        return context.Meals.Count();
    }

    public async Task<bool> CreateAsync(Meal meal)
    {
        context.Add(meal);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var meal = await context.Meals.Include(m => m.Ingredients).FirstAsync(m => m.Id == id);
        context.Remove(meal);
        await context.SaveChangesAsync();
    }

    public async Task<List<Meal>> GetAllAsync()
    {
        return await context.Meals.ToListAsync();
    }

    public async Task<Meal?> GetByIdAsync(int id)
    {
        return await context.Meals.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Meal> GetOneAsync()
    {
        return await context.Meals.FirstAsync();
    }

    public async Task<List<MealIngredients>> GetIngredientsAsync(int mealId)
    {
        return await context.MealIngredients.Where(m => m.MealId == mealId).ToListAsync();
     }

    public async Task<Meal> UpdateAsync(Meal meal)
    {
        context.Update(meal);
        await context.SaveChangesAsync();
        return meal;
    }

    public async Task<Meal> getMealApplyingRules(DateTime date)
    {
        var lastMeal = await _historyRepository.GetLast(date);
        var ingredients = await GetIngredientsAsync(lastMeal.MealId);
        var ingredientIds = ingredients.Select(i => i.IngredientId).ToList();
        var query = 
            (
            from mealIngredient in context.MealIngredients
            where !ingredientIds.Contains(mealIngredient.IngredientId)
            select new Meal
            {
                Id = mealIngredient.MealId
            }).Take(1);
        foreach(Meal meal in query)
        {
            return meal;
        }

        throw new Exception("Insufficient data");
    }
}
