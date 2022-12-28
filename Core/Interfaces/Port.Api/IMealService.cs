using Core.DTO.Meal;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Port.Api;

public interface IMealService
{
    Task<GetMealDto> AddAsync(AddMealDto meal);
    Task<List<GetMealDto>> GetAllAsync();
    Task<GetMealDto> GetByIdAsync(int id);
    Task<GetMealDto> UpdateAsync(UpdateMealDto meal);
    Task DeleteAsync(int id);
}
