using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class addvalordiaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Quarto_QuartoId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_QuartoId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "QuartoId",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Quarto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValorDiaria",
                table: "Hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_HotelId",
                table: "Quarto",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quarto_Hotels_HotelId",
                table: "Quarto",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quarto_Hotels_HotelId",
                table: "Quarto");

            migrationBuilder.DropIndex(
                name: "IX_Quarto_HotelId",
                table: "Quarto");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Quarto");

            migrationBuilder.DropColumn(
                name: "ValorDiaria",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "QuartoId",
                table: "Hotels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_QuartoId",
                table: "Hotels",
                column: "QuartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Quarto_QuartoId",
                table: "Hotels",
                column: "QuartoId",
                principalTable: "Quarto",
                principalColumn: "Id");
        }
    }
}
