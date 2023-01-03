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

    public int Count()
    {
       return context.MealHistories.Count();
    }

    public async Task<List<MealHistory>> GetAll()
    {
        return await context.MealHistories.ToListAsync();
    }

    public async Task<MealHistory?> GetByDay(DateTime date)
    {
        return await context.MealHistories.FirstOrDefaultAsync(h => h.Date == date);
    }
}
