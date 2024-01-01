using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    /// <inheritdoc />
    public partial class fix_Uzytkownik_Model_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownik_RolaUzytkownika_RolaUzytkownikaId",
                table: "Uzytkownik");

            migrationBuilder.AlterColumn<int>(
                name: "RolaUzytkownikaId",
                table: "Uzytkownik",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytokwnik_RolaUzytkownika",
                table: "Uzytkownik",
                column: "RolaUzytkownikaId",
                principalTable: "RolaUzytkownika",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytokwnik_RolaUzytkownika",
                table: "Uzytkownik");

            migrationBuilder.AlterColumn<int>(
                name: "RolaUzytkownikaId",
                table: "Uzytkownik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownik_RolaUzytkownika_RolaUzytkownikaId",
                table: "Uzytkownik",
                column: "RolaUzytkownikaId",
                principalTable: "RolaUzytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
