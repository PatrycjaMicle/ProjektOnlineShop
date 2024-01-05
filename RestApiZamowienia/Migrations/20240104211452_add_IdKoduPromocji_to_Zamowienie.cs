using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class add_IdKoduPromocji_to_Zamowienie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdKoduPromocji",
                table: "Zamowienie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKoduPromocji",
                table: "Zamowienie",
                column: "IdKoduPromocji");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_KodPromocji",
                table: "Zamowienie",
                column: "IdKoduPromocji",
                principalTable: "KodPromocji",
                principalColumn: "IdKoduPromocji");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_KodPromocji",
                table: "Zamowienie");

            migrationBuilder.DropIndex(
                name: "IX_Zamowienie_IdKoduPromocji",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "IdKoduPromocji",
                table: "Zamowienie");
        }
    }
}
