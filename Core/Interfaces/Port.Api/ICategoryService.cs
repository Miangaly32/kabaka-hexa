using Core.Models;

namespace Core.Interfaces.Port.Api;

public interface ICategoryService
{
    Task<bool> AddAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> UpdateAsync(Category category);
    Task DeleteAsync(int id);
}
