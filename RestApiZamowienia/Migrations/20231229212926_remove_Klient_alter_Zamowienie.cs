using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class remove_Klient_alter_Zamowienie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_Klient",
                table: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.RenameColumn(
                name: "IdKlienta",
                table: "Zamowienie",
                newName: "IdUzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienie_IdKlienta",
                table: "Zamowienie",
                newName: "IX_Zamowienie_IdUzytkownika");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_Uzytkownik",
                table: "Zamowienie",
                column: "IdUzytkownika",
                principalTable: "Uzytkownik",
                principalColumn: "IdUzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienie_Uzytkownik",
                table: "Zamowienie");

            migrationBuilder.RenameColumn(
                name: "IdUzytkownika",
                table: "Zamowienie",
                newName: "IdKlienta");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienie_IdUzytkownika",
                table: "Zamowienie",
                newName: "IX_Zamowienie_IdKlienta");

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdresu = table.Column<int>(type: "int", nullable: true),
                    KtoDodal = table.Column<int>(type: "int", nullable: true),
                    KtoUsunal = table.Column<int>(type: "int", nullable: true),
                    KtoZmodyfikowal = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KiedyDodano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KiedyUsunieto = table.Column<DateTime>(type: "datetime", nullable: true),
                    KiedyZmodyfikowano = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.IdKlienta);
                    table.ForeignKey(
                        name: "FK_Klient_Adres",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu");
                    table.ForeignKey(
                        name: "FK_Klient_Uzytkownik",
                        column: x => x.KtoDodal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Klient_Uzytkownik1",
                        column: x => x.KtoZmodyfikowal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Klient_Uzytkownik2",
                        column: x => x.KtoUsunal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klient_IdAdresu",
                table: "Klient",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_KtoDodal",
                table: "Klient",
                column: "KtoDodal");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_KtoUsunal",
                table: "Klient",
                column: "KtoUsunal");

            migrationBuilder.CreateIndex(
                name: "IX_Klient_KtoZmodyfikowal",
                table: "Klient",
                column: "KtoZmodyfikowal");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienie_Klient",
                table: "Zamowienie",
                column: "IdKlienta",
                principalTable: "Klient",
                principalColumn: "IdKlienta");
        }
    }
}
