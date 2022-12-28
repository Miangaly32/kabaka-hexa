using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adapter.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class meals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Color_ColorId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unitId = table.Column<int>(type: "int", nullable: false),
                    ingredientId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_Ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientQuantities_Units_unitId",
                        column: x => x.unitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_ingredientId",
                table: "IngredientQuantities",
                column: "ingredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_MealId",
                table: "IngredientQuantities",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantities_unitId",
                table: "IngredientQuantities",
                column: "unitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Colors_ColorId",
                table: "Ingredients",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Colors_ColorId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "IngredientQuantities");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Color_ColorId",
                table: "Ingredients",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
