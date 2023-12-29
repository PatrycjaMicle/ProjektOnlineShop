using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class remove_sesjaKoszyka_alter_ElementKoszyka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementKoszyka_SesjaKoszyka",
                table: "ElementKoszyka");

            migrationBuilder.DropTable(
                name: "SesjaKoszyka");

            migrationBuilder.RenameColumn(
                name: "IdSesjiKoszyka",
                table: "ElementKoszyka",
                newName: "IdUzytkownika");

            migrationBuilder.RenameIndex(
                name: "IX_ElementKoszyka_IdSesjiKoszyka",
                table: "ElementKoszyka",
                newName: "IX_ElementKoszyka_IdUzytkownika");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementKoszyka_Uzytkownik",
                table: "ElementKoszyka",
                column: "IdUzytkownika",
                principalTable: "Uzytkownik",
                principalColumn: "IdUzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementKoszyka_Uzytkownik",
                table: "ElementKoszyka");

            migrationBuilder.RenameColumn(
                name: "IdUzytkownika",
                table: "ElementKoszyka",
                newName: "IdSesjiKoszyka");

            migrationBuilder.RenameIndex(
                name: "IX_ElementKoszyka_IdUzytkownika",
                table: "ElementKoszyka",
                newName: "IX_ElementKoszyka_IdSesjiKoszyka");

            migrationBuilder.CreateTable(
                name: "SesjaKoszyka",
                columns: table => new
                {
                    IdSesjiKoszyka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUzytkownika = table.Column<int>(type: "int", nullable: true),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime", nullable: true),
                    Suma = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesjaKoszyka", x => x.IdSesjiKoszyka);
                    table.ForeignKey(
                        name: "FK_SesjaKoszyka_Uzytkownik",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SesjaKoszyka_IdUzytkownika",
                table: "SesjaKoszyka",
                column: "IdUzytkownika");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementKoszyka_SesjaKoszyka",
                table: "ElementKoszyka",
                column: "IdSesjiKoszyka",
                principalTable: "SesjaKoszyka",
                principalColumn: "IdSesjiKoszyka");
        }
    }
}
