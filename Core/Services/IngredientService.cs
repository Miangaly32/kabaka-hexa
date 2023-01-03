using Core.DTO.Ingredients;
using Core.Interfaces.Port.Api;
using Core.Interfaces.Repositories;
using Core.Models;

namespace Core.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _repository;

    public IngredientService(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetIngredientDto> AddAsync(AddIngredientDto request)
    {
        var ingredient = Mapping.Mapper.Map<Ingredient>(request);
        await _repository.CreateAsync(ingredient);

        return Mapping.Mapper.Map<GetIngredientDto>(ingredient);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<GetIngredientDto>> GetAllAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        return ingredients.Select(ingredient => Mapping.Mapper.Map<GetIngredientDto>(ingredient)).ToList();
    }

    public async Task<GetIngredientDto> GetByIdAsync(int id)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        if (ingredient == null)
            throw new Exception("Ingredient not found");

        return Mapping.Mapper.Map<GetIngredientDto>(ingredient);
    }

    public async Task<GetIngredientDto> UpdateAsync(UpdateIngredientDto request)
    {
        var ingredient = await _repository.UpdateAsync(Mapping.Mapper.Map<Ingredient>(request));

        return Mapping.Mapper.Map<GetIngredientDto>(ingredient);
    }
}
