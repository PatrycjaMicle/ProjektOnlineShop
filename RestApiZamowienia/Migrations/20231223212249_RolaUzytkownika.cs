using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class RolaUzytkownika : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodaPlatnosci",
                columns: table => new
                {
                    IdMetodyPlatnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodaPlatnosci", x => x.IdMetodyPlatnosci);
                });

            migrationBuilder.CreateTable(
                name: "RolaUzytkownika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolaUzytkownika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DataDodania = table.Column<DateTime>(type: "datetime", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZahaszowaneHaslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolaUzytkownikaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.IdUzytkownika);
                    table.ForeignKey(
                        name: "FK_Uzytkownik_RolaUzytkownika_RolaUzytkownikaId",
                        column: x => x.RolaUzytkownikaId,
                        principalTable: "RolaUzytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kraj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrBudynku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NrLokalu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KtoDodal = table.Column<int>(type: "int", nullable: true),
                    KiedyDodano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoEdytowal = table.Column<int>(type: "int", nullable: true),
                    KiedyEdytowano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoUsunal = table.Column<int>(type: "int", nullable: true),
                    KiedyUsunieto = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.IdAdresu);
                    table.ForeignKey(
                        name: "FK_Adres_Uzytkownik",
                        column: x => x.KtoDodal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Adres_Uzytkownik1",
                        column: x => x.KtoEdytowal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Adres_Uzytkownik2",
                        column: x => x.KtoUsunal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KtoDodal = table.Column<int>(type: "int", nullable: true),
                    KiedyDodano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoEdytowal = table.Column<int>(type: "int", nullable: true),
                    KiedyEdytowano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoUsunal = table.Column<int>(type: "int", nullable: true),
                    KiedyUsunieto = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.IdKategorii);
                    table.ForeignKey(
                        name: "FK_Kategoria_Uzytkownik",
                        column: x => x.KtoDodal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Kategoria_Uzytkownik1",
                        column: x => x.KtoEdytowal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Kategoria_Uzytkownik2",
                        column: x => x.KtoUsunal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdAdresu = table.Column<int>(type: "int", nullable: true),
                    KtoDodal = table.Column<int>(type: "int", nullable: true),
                    KiedyDodano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoZmodyfikowal = table.Column<int>(type: "int", nullable: true),
                    KiedyZmodyfikowano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoUsunal = table.Column<int>(type: "int", nullable: true),
                    KiedyUsunieto = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Towar",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdKategorii = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    NaStanie = table.Column<bool>(type: "bit", nullable: true),
                    ZdjecieUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KiedyDodano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoDodal = table.Column<int>(type: "int", nullable: true),
                    KiedyZmodyfikowano = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoZmodyfikowal = table.Column<int>(type: "int", nullable: true),
                    KiedyUsunieto = table.Column<DateTime>(type: "datetime", nullable: true),
                    KtoUsunal = table.Column<int>(type: "int", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towar", x => x.IdTowaru);
                    table.ForeignKey(
                        name: "FK_Towar_Kategoria",
                        column: x => x.IdKategorii,
                        principalTable: "Kategoria",
                        principalColumn: "IdKategorii");
                    table.ForeignKey(
                        name: "FK_Towar_Uzytkownik",
                        column: x => x.KtoDodal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Towar_Uzytkownik1",
                        column: x => x.KtoUsunal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Towar_Uzytkownik2",
                        column: x => x.KtoZmodyfikowal,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateTable(
                name: "SesjaKoszyka",
                columns: table => new
                {
                    IdSesjiKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKlienta = table.Column<int>(type: "int", nullable: true),
                    Suma = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesjaKoszyka", x => x.IdSesjiKoszyka);
                    table.ForeignKey(
                        name: "FK_SesjaKoszyka_Klient",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta");
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdKlienta = table.Column<int>(type: "int", nullable: true),
                    TerminDostawy = table.Column<DateTime>(type: "datetime", nullable: true),
                    Suma = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    IdMetodyPlatnosci = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Klient",
                        column: x => x.IdKlienta,
                        principalTable: "Klient",
                        principalColumn: "IdKlienta");
                    table.ForeignKey(
                        name: "FK_Zamowienie_MetodaPlatnosci",
                        column: x => x.IdMetodyPlatnosci,
                        principalTable: "MetodaPlatnosci",
                        principalColumn: "IdMetodyPlatnosci");
                });

            migrationBuilder.CreateTable(
                name: "ElementKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<int>(type: "int", nullable: true),
                    IdTowaru = table.Column<int>(type: "int", nullable: true),
                    Ilosc = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_SesjaKoszyka",
                        column: x => x.IdSesjiKoszyka,
                        principalTable: "SesjaKoszyka",
                        principalColumn: "IdSesjiKoszyka");
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_Towar",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru");
                });

            migrationBuilder.CreateTable(
                name: "TowarZamowienia",
                columns: table => new
                {
                    IdTowaruZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTowaru = table.Column<int>(type: "int", nullable: true),
                    IdZamowienia = table.Column<int>(type: "int", nullable: true),
                    Ilosc = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Aktywny = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowarZamowienia", x => x.IdTowaruZamowienia);
                    table.ForeignKey(
                        name: "FK_TowarZamowienia_Towar",
                        column: x => x.IdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru");
                    table.ForeignKey(
                        name: "FK_TowarZamowienia_Zamowienie",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_KtoDodal",
                table: "Adres",
                column: "KtoDodal");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_KtoEdytowal",
                table: "Adres",
                column: "KtoEdytowal");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_KtoUsunal",
                table: "Adres",
                column: "KtoUsunal");

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_IdSesjiKoszyka",
                table: "ElementKoszyka",
                column: "IdSesjiKoszyka");

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_IdTowaru",
                table: "ElementKoszyka",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoria_KtoDodal",
                table: "Kategoria",
                column: "KtoDodal");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoria_KtoEdytowal",
                table: "Kategoria",
                column: "KtoEdytowal");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoria_KtoUsunal",
                table: "Kategoria",
                column: "KtoUsunal");

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

            migrationBuilder.CreateIndex(
                name: "IX_SesjaKoszyka_IdKlienta",
                table: "SesjaKoszyka",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_IdKategorii",
                table: "Towar",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_KtoDodal",
                table: "Towar",
                column: "KtoDodal");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_KtoUsunal",
                table: "Towar",
                column: "KtoUsunal");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_KtoZmodyfikowal",
                table: "Towar",
                column: "KtoZmodyfikowal");

            migrationBuilder.CreateIndex(
                name: "IX_TowarZamowienia_IdTowaru",
                table: "TowarZamowienia",
                column: "IdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_TowarZamowienia_IdZamowienia",
                table: "TowarZamowienia",
                column: "IdZamowienia");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_RolaUzytkownikaId",
                table: "Uzytkownik",
                column: "RolaUzytkownikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdKlienta",
                table: "Zamowienie",
                column: "IdKlienta");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_IdMetodyPlatnosci",
                table: "Zamowienie",
                column: "IdMetodyPlatnosci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszyka");

            migrationBuilder.DropTable(
                name: "TowarZamowienia");

            migrationBuilder.DropTable(
                name: "SesjaKoszyka");

            migrationBuilder.DropTable(
                name: "Towar");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "MetodaPlatnosci");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "RolaUzytkownika");
        }
    }
}
