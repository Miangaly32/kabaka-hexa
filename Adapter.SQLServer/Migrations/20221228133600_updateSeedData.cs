using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Ingredients_ingredientId",
                table: "IngredientQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Units_unitId",
                table: "IngredientQuantities");

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "unitId",
                table: "IngredientQuantities",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "IngredientQuantities",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ingredientId",
                table: "IngredientQuantities",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientQuantities_unitId",
                table: "IngredientQuantities",
                newName: "IX_IngredientQuantities_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientQuantities_ingredientId",
                table: "IngredientQuantities",
                newName: "IX_IngredientQuantities_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Ingredients_IngredientId",
                table: "IngredientQuantities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Units_UnitId",
                table: "IngredientQuantities",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Ingredients_IngredientId",
                table: "IngredientQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientQuantities_Units_UnitId",
                table: "IngredientQuantities");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "IngredientQuantities",
                newName: "unitId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "IngredientQuantities",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "IngredientQuantities",
                newName: "ingredientId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientQuantities_UnitId",
                table: "IngredientQuantities",
                newName: "IX_IngredientQuantities_unitId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientQuantities_IngredientId",
                table: "IngredientQuantities",
                newName: "IX_IngredientQuantities_ingredientId");

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[] { 2, "Gramme", "g" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Ingredients_ingredientId",
                table: "IngredientQuantities",
                column: "ingredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientQuantities_Units_unitId",
                table: "IngredientQuantities",
                column: "unitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
