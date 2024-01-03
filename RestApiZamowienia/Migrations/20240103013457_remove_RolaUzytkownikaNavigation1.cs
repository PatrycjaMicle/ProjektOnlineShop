using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class remove_RolaUzytkownikaNavigation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytokwnik_RolaUzytkownika",
                table: "Uzytkownik");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownik_RolaUzytkownikaId",
                table: "Uzytkownik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_RolaUzytkownikaId",
                table: "Uzytkownik",
                column: "RolaUzytkownikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytokwnik_RolaUzytkownika",
                table: "Uzytkownik",
                column: "RolaUzytkownikaId",
                principalTable: "RolaUzytkownika",
                principalColumn: "Id");
        }
    }
}
