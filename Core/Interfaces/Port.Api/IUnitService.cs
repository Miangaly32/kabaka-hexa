using Core.Models;

namespace Core.Interfaces.Port.Api;

public interface IUnitService
{
    Task<List<Unit>> GetAllAsync();
}
