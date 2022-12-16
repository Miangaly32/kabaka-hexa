using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Adapter.SQLServer.Tests;

public class AppDbContextFactory1 : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;
        return new AppDbContext(options);
    }
}