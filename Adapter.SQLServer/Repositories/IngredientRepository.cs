using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly AppDbContext context;

    public IngredientRepository(AppDbContext appDBContext)
    {
        context = appDBContext;
    }

    public async Task<bool> CreateAsync(Ingredient ingredient)
    {
        try
        {
            var category = await context.Categories.FindAsync(ingredient.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            ingredient.Category = category;
            context.Add(ingredient);
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
        var ingredient = await context.Ingredients.FindAsync(id);
        context.Remove(ingredient);
        await context.SaveChangesAsync();

    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await context.Ingredients.Include(i => i.Category).ToListAsync();
    }

    public async Task<Ingredient?> GetByIdAsync(int id)
    {
        return await context.Ingredients
                        .Include(i => i.Category)
                        .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Ingredient> UpdateAsync(Ingredient ingredient)
    {
        context.Update(ingredient);
        await context.SaveChangesAsync();
        return ingredient;
    }
}