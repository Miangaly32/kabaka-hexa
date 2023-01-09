using Core.Interfaces.Port.Api;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MealHistoryController : ControllerBase
{
    private readonly IMealHistoryService _service;

    public MealHistoryController(IMealHistoryService service) 
    { 
        _service= service;
    }

    [HttpGet("MealOfTheDay")]
    public async Task<IActionResult> GetMealOfTheDay()
    {
        try
        {
            return Ok(await _service.GetByDate(DateTime.Today));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
