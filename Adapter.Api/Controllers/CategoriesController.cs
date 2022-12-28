using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Port.Api;
using Core.Models;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAction(Category category)
    {
        await _categoryService.AddAsync(category);
        return Created($"/Categories/{category.Id}", category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAction()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAction(int id)
    {
        return Ok(await _categoryService.GetByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAction(int id, Category category)
    {
        if (id != category.Id)
            return BadRequest();

        return Ok(await _categoryService.UpdateAsync(category));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAction(int id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }
}