using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Adapter.SQLServer;

public class AppDbContext : IdentityUserContext<IdentityUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<MealHistory> MealHistories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public AppDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Color>().HasData(
            new Color
            {
                Id = 1,
                Name = "Rouge",
            },
            new Color
            {
                Id = 2,
                Name = "Vert",
            },
            new Color
            {
                Id = 3,
                Name = "Jaune",
            },
            new Color
            {
                Id = 4,
                Name = "Orange",
            },
            new Color
            {
                Id = 5,
                Name = "Blanc",
            }
        );

        modelBuilder.Entity<Unit>().HasData(
          new Unit
          {
              Id = 1,
              Name = "Kilogramme",
              Symbol= "kg",
          },
          new Unit
          {
              Id = 3,
              Name = "Piece",
              Symbol = "pcs",
          },
          new Unit
          {
              Id = 4,
              Name = "Litre",
              Symbol = "l",
          },
          new Unit
          {
              Id = 5,
              Name = "Millilitre",
              Symbol = "ml",
          }
        );
    }
}