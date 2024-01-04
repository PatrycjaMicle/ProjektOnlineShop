using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class create_Prmocja_and_Kod_ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kod",
                columns: table => new
                {
                    IdKodu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kod", x => x.IdKodu);
                });

            migrationBuilder.CreateTable(
                name: "Promocja",
                columns: table => new
                {
                    IdPromocji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wartosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocja", x => x.IdPromocji);
                });

            migrationBuilder.CreateTable(
                name: "KodPromocji",
                columns: table => new
                {
                    IdKoduPromocji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPromocji = table.Column<int>(type: "int", nullable: true),
                    IdKodu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KodPromocji", x => x.IdKoduPromocji);
                    table.ForeignKey(
                        name: "FK_KodPromocji_Kod",
                        column: x => x.IdKodu,
                        principalTable: "Kod",
                        principalColumn: "IdKodu");
                    table.ForeignKey(
                        name: "FK_KodPromocji_Promocja",
                        column: x => x.IdPromocji,
                        principalTable: "Promocja",
                        principalColumn: "IdPromocji");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KodPromocji_IdKodu",
                table: "KodPromocji",
                column: "IdKodu");

            migrationBuilder.CreateIndex(
                name: "IX_KodPromocji_IdPromocji",
                table: "KodPromocji",
                column: "IdPromocji");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KodPromocji");

            migrationBuilder.DropTable(
                name: "Kod");

            migrationBuilder.DropTable(
                name: "Promocja");
        }
    }
}
