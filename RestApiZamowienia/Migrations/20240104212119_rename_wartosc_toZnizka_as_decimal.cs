using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class rename_wartosc_toZnizka_as_decimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wartosc",
                table: "Promocja");

            migrationBuilder.AddColumn<decimal>(
                name: "ZnizkaWProcentach",
                table: "Promocja",
                type: "decimal(18,0)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZnizkaWProcentach",
                table: "Promocja");

            migrationBuilder.AddColumn<string>(
                name: "Wartosc",
                table: "Promocja",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
