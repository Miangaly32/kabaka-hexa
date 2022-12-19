using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Port.Api;
using Core.Models;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AddCategoryController : ControllerBase
{
    private readonly IAddCategory _addCategory;

    public AddCategoryController(IAddCategory addCategory)
    {
        this._addCategory = addCategory;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAction(Category category)
    {
        return Ok(await this._addCategory.AddCategoryAsync(category));
    }
}