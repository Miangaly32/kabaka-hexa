using Core.DTO.Ingredients;
using Core.Interfaces.Port.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    
    public IngredientsController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAction(AddIngredientDto request)
    {
        var ingredient = await _ingredientService.AddAsync(request);
        return Created($"/Ingredients/{ingredient.Id}", ingredient);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAction()
    {
        return Ok(await _ingredientService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAction(int id)
    {
        try
        {
            var ingredient = await _ingredientService.GetByIdAsync(id);
            return Ok(ingredient);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAction(int id, UpdateIngredientDto request)
    {
        if (id != request.Id)
            return BadRequest();

        try
        {
            var ingredient = await _ingredientService.UpdateAsync(request);
            return Ok(ingredient);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAction(int id)
    {
        await _ingredientService.DeleteAsync(id);
        return NoContent();
    }
}
