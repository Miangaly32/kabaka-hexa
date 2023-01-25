using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.SQLServer.Repositories;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext context;

    public UnitRepository(AppDbContext appDbContext)
    {
        context= appDbContext;
    }

    public async Task<List<Unit>> GetAllAsync()
    {
        return await context.Units.ToListAsync();
    }
}
