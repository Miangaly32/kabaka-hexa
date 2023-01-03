using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class modif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Meals_MealId",
                table: "IngredientQuantities");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "IngredientQuantities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Meals_MealId",
                table: "IngredientQuantities",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Meals_MealId",
                table: "IngredientQuantities");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "IngredientQuantities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Meals_MealId",
                table: "IngredientQuantities",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }
    }
}
