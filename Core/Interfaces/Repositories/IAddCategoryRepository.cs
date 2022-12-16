using Core.Models;

namespace Core.Interfaces.Repositories;

//SQLServer, PostgreSQL, MySQL
public interface IAddCategoryRepository
{
    Task<bool> CreateCategoryAsync(Category category);
}