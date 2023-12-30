using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class remove_relationship_zamowienie_towar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowarZamowienia_Towar",
                table: "TowarZamowienia");

            migrationBuilder.DropIndex(
                name: "IX_TowarZamowienia_IdTowaru",
                table: "TowarZamowienia");

            migrationBuilder.DropColumn(
                name: "IdTowaru",
                table: "TowarZamowienia");

            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "TowarZamowienia",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazwaTowaru",
                table: "TowarZamowienia",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "TowarZamowienia");

            migrationBuilder.DropColumn(
                name: "NazwaTowaru",
                table: "TowarZamowienia");

            migrationBuilder.AddColumn<int>(
                name: "IdTowaru",
                table: "TowarZamowienia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TowarZamowienia_IdTowaru",
                table: "TowarZamowienia",
                column: "IdTowaru");

            migrationBuilder.AddForeignKey(
                name: "FK_TowarZamowienia_Towar",
                table: "TowarZamowienia",
                column: "IdTowaru",
                principalTable: "Towar",
                principalColumn: "IdTowaru");
        }
    }
}
