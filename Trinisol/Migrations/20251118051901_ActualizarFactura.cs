using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinisol.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetodoPago",
                table: "Facturas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "NumeroFactura",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Pago",
                table: "Facturas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoPendiente",
                table: "Facturas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "NumeroFactura",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "SaldoPendiente",
                table: "Facturas");
        }
    }
}
