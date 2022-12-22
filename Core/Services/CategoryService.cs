using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;
public class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> AddAsync(Category category)
    {
        return await _repository.CreateAsync(category);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        return await _repository.UpdateAsync(category);
    }
}
