using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class AddCategoryRepository : IAddCategoryRepository
{
    private readonly AppDbContext context;

    public AddCategoryRepository(AppDbContext appDBContext)
    {
        context = appDBContext;
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        try
        {
            context.Add(category);
            await context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }
}