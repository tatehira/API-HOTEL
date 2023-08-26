using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class posdelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quarto_Hotels_HotelId",
                table: "Quarto");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_QuartoId",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quarto",
                table: "Quarto");

            migrationBuilder.RenameTable(
                name: "Reserva",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "Quarto",
                newName: "Quartos");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_QuartoId",
                table: "Reservas",
                newName: "IX_Reservas_QuartoId");

            migrationBuilder.RenameIndex(
                name: "IX_Quarto_HotelId",
                table: "Quartos",
                newName: "IX_Quartos_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quartos",
                table: "Quartos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quartos_Hotels_HotelId",
                table: "Quartos",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quartos_Hotels_HotelId",
                table: "Quartos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quartos",
                table: "Quartos");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reserva");

            migrationBuilder.RenameTable(
                name: "Quartos",
                newName: "Quarto");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_QuartoId",
                table: "Reserva",
                newName: "IX_Reserva_QuartoId");

            migrationBuilder.RenameIndex(
                name: "IX_Quartos_HotelId",
                table: "Quarto",
                newName: "IX_Quarto_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserva",
                table: "Reserva",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quarto",
                table: "Quarto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quarto_Hotels_HotelId",
                table: "Quarto",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_QuartoId",
                table: "Reserva",
                column: "QuartoId",
                principalTable: "Quarto",
                principalColumn: "Id");
        }
    }
}
