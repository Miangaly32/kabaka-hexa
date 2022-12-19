using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Adapter.SQLServer;

public class AppDbContext : IdentityUserContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }
}