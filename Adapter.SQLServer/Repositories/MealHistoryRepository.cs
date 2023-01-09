using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class MealHistoryRepository : IMealHistoryRepository
{
    private readonly AppDbContext context;

    public MealHistoryRepository(AppDbContext appDbContext)
    {
        context = appDbContext;
    }

    public async Task<bool> AddAsync(MealHistory meal)
    {
        context.Add(meal);
        await context.SaveChangesAsync();
        return true;
    }

    public int Count()
    {
       return context.MealHistories.Count();
    }

    public async Task<List<MealHistory>> GetAll()
    {
        return await context.MealHistories.ToListAsync();
    }

    public async Task<MealHistory?> GetHistoryByDate(DateTime date)
    {
        return await context.MealHistories.Include(h => h.Meal).Where(h => h.Date == date.Date).FirstOrDefaultAsync();
    }

    public async Task<MealHistory> GetLast(DateTime date)
    {
        date = date.AddDays(-1);
        var history = await context.MealHistories.Where(h => h.Date == date.Date).FirstOrDefaultAsync();
        if (history == null)
        {
            return await GetLast(date);
        }
        return history;
    }
}
