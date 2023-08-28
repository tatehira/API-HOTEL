using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class adcquartovalor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDiaria",
                table: "Hotels");

            migrationBuilder.AddColumn<double>(
                name: "ValorDiaria",
                table: "Quartos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorDiaria",
                table: "Quartos");

            migrationBuilder.AddColumn<double>(
                name: "ValorDiaria",
                table: "Hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
