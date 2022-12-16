using Core.Models;

namespace Core.Interfaces.Port.Api;

//API, CLI, Blazor
public interface IAddCategory
{
    Task<bool> AddCategoryAsync(Category category);
}
