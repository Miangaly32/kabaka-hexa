using Core.Models;

namespace Core.Interfaces.Repositories;

//SQLServer, PostgreSQL, MySQL
public interface ICategoryRepository
{
    Task<bool> CreateAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> UpdateAsync(Category category);

    Task DeleteAsync(int id);
}