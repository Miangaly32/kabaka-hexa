using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Adapter.SQLServer;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }
}