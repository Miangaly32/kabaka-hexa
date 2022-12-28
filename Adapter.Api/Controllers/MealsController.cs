using Core.DTO.Meal;
using Core.Interfaces.Port.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MealsController : ControllerBase
{ 
    private readonly IMealService _mealService;

    public MealsController(IMealService mealService)
    {
        _mealService = mealService;
    }


    [HttpPost]
    public async Task<IActionResult> AddAction(AddMealDto request)
    {
        var meal = await _mealService.AddAsync(request);
        return Created($"/Meals/{meal.Id}", meal);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAction()
    {
        return Ok(await _mealService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAction(int id)
    {
        try
        {
            var meal = await _mealService.GetByIdAsync(id);
            return Ok(meal);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAction(int id, UpdateMealDto request)
    {
        if (id != request.Id)
            return BadRequest();

        try
        {
            var meal = await _mealService.UpdateAsync(request);
            return Ok(meal);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAction(int id)
    {
        try
        {
            await _mealService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
