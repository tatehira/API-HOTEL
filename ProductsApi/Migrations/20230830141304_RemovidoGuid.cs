using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovidoGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quartos_Hotels_HotelId",
                table: "Quartos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "HotelKey",
                table: "Quartos");

            migrationBuilder.DropColumn(
                name: "SenhaHotel",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "QuartoId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Quartos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuartoId",
                table: "Quartos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Quartos_Hotels_HotelId",
                table: "Quartos",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Quartos_QuartoId",
                table: "Reservas",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "QuartoId",
                table: "Quartos");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "QuartoId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Quartos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelKey",
                table: "Quartos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenhaHotel",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
