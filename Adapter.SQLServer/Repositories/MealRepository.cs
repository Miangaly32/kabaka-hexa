using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class MealRepository : IMealRepository
{
    private readonly AppDbContext context;

    public MealRepository(AppDbContext appDbContext)
    {
        context= appDbContext;
    }

    public async Task<bool> CreateAsync(Meal meal)
    {
        try
        {
            context.Add(meal);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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

    public async Task<Meal> UpdateAsync(Meal meal)
    {
        context.Update(meal);
        await context.SaveChangesAsync();
        return meal;
    }
}
