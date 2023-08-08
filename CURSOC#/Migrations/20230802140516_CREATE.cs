using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CURSOC_.Migrations
{
    /// <inheritdoc />
    public partial class CREATE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "conprovincia", "nomprovincia" },
                values: new object[,]
                {
                    { 1, "SAN JOSE" },
                    { 2, "ALAJUELA" },
                    { 3, "CARTAGO" },
                    { 4, "HEREDIA" },
                    { 5, "GUANACASTE" },
                    { 6, "PUNTARENAS" },
                    { 7, "LIMON" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "conprovincia",
                keyValue: 7);
        }
    }
}
