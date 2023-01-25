using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IUnitRepository
{
    Task<List<Unit>> GetAllAsync();
}
