using Core.Interfaces.Port.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UnitsController : ControllerBase
{
    private readonly IUnitService _service;

    public UnitsController(IUnitService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAction()
    {
        return Ok(await _service.GetAllAsync());
    }
}
