using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class SesjaKoszykaUzytkowik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SesjaKoszyka_Klient",
                table: "SesjaKoszyka");

            migrationBuilder.RenameColumn(
                name: "IdKlienta",
                table: "SesjaKoszyka",
                newName: "IdUzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_SesjaKoszyka_IdKlienta",
                table: "SesjaKoszyka",
                newName: "IX_SesjaKoszyka_IdUzytkownika");

            migrationBuilder.AddForeignKey(
                name: "FK_SesjaKoszyka_Uzytkownik",
                table: "SesjaKoszyka",
                column: "IdUzytkownika",
                principalTable: "Uzytkownik",
                principalColumn: "IdUzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SesjaKoszyka_Uzytkownik",
                table: "SesjaKoszyka");

            migrationBuilder.RenameColumn(
                name: "IdUzytkownika",
                table: "SesjaKoszyka",
                newName: "IdKlienta");

            migrationBuilder.RenameIndex(
                name: "IX_SesjaKoszyka_IdUzytkownika",
                table: "SesjaKoszyka",
                newName: "IX_SesjaKoszyka_IdKlienta");

            migrationBuilder.AddForeignKey(
                name: "FK_SesjaKoszyka_Klient",
                table: "SesjaKoszyka",
                column: "IdKlienta",
                principalTable: "Klient",
                principalColumn: "IdKlienta");
        }
    }
}
