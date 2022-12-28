using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adapter.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class addUnitSymbol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rouge" },
                    { 2, "Vert" },
                    { 3, "Jaune" },
                    { 4, "Orange" },
                    { 5, "Blanc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Units");
        }
    }
}
