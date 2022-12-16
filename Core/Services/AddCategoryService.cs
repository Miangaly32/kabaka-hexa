using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;
public class AddCategoryService: IAddCategory
{
    private readonly IAddCategoryRepository _repository;

    public AddCategoryService(IAddCategoryRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> AddCategoryAsync(Category category)
    {
        return await _repository.CreateCategoryAsync(category);
    }
}
