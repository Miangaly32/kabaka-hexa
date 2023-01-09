using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateMealIngredientsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"create view MealIngredients " +
                $"as select iq.MealId, i.Name Ingredient, i.Id IngredientId, col.Id ColorId," +
                $" c.Name Category, iq.Quantity, u.Symbol from IngredientQuantities iq " +
                $"join Ingredients i on iq.IngredientId = i.Id join Categories c on i.CategoryId = c.Id " +
                $"join Colors col on i.ColorId = col.Id join Units u on iq.UnitId = u.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW MealIngredients");
        }
    }
}
