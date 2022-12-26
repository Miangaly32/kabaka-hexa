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

    public async Task<Ingredient> AddAsync(IngredientRequest request)
    {
        var ingredient = new Ingredient
        {
            Name= request.Name,
            Color= request.Color,
            CategoryId = request.CategoryId
        };
        await _repository.CreateAsync(ingredient);
        return ingredient;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<List<IngredientResponse>> GetAllAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        var responses = new List<IngredientResponse>();
        ingredients.ForEach(i =>
        {
            var response = new IngredientResponse();
            response.Id = i.Id;
            response.Name = i.Name;
            response.Color = i.Color;
            response.Category = i.Category;
            responses.Add(response);
        });
        return responses;
    }

    public async Task<IngredientResponse> GetByIdAsync(int id)
    {
        var ingredient = await _repository.GetByIdAsync(id);
        if (ingredient == null)
            throw new Exception("Ingredient not found");

        var response = new IngredientResponse();
        response.Id = ingredient.Id;
        response.Name = ingredient.Name;
        response.Color = ingredient.Color;
        response.Category = ingredient.Category;
        return response;
    }

    public async Task<Ingredient> UpdateAsync(IngredientRequest request)
    {
        var ingredient = new Ingredient
        {
            Id = request.Id,
            Name = request.Name,
            Color = request.Color,
            CategoryId = request.CategoryId
        };
        return await _repository.UpdateAsync(ingredient);
    }
}
