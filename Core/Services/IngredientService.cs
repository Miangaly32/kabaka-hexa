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
        var ingredient = new Ingredient
        {
            Name= request.Name,
            Color= request.Color,
            CategoryId = request.CategoryId
        };
        await _repository.CreateAsync(ingredient);

        var response = new GetIngredientDto();
        response.Id = ingredient.Id;
        response.Name = ingredient.Name;
        response.Color = ingredient.Color;
        response.Category = ingredient.Category;

        return response;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<GetIngredientDto>> GetAllAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        var responses = new List<GetIngredientDto>();
        ingredients.ForEach(i =>
        {
            var response = new GetIngredientDto();
            response.Id = i.Id;
            response.Name = i.Name;
            response.Color = i.Color;
            response.Category = i.Category;
            responses.Add(response);
        });
        return responses;
    }

    public async Task<GetIngredientDto> GetByIdAsync(int id)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        if (ingredient == null)
            throw new Exception("Ingredient not found");

        var response = new GetIngredientDto();
        response.Id = ingredient.Id;
        response.Name = ingredient.Name;
        response.Color = ingredient.Color;
        response.Category = ingredient.Category;
        return response;
    }

    public async Task<GetIngredientDto> UpdateAsync(UpdateIngredientDto request)
    {
        var ingredient = new Ingredient
        {
            Id = request.Id,
            Name = request.Name,
            Color = request.Color,
            CategoryId = request.CategoryId
        };
        ingredient = await _repository.UpdateAsync(ingredient);

        var response = new GetIngredientDto();
        response.Id = ingredient.Id;
        response.Name = ingredient.Name;
        response.Color = ingredient.Color;
        response.Category = ingredient.Category;

        return response;
    }
}
