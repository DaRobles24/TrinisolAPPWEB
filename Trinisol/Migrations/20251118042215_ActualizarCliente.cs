using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinisol.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DireccionGoogleMaps",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TipoCliente",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DireccionGoogleMaps",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "TipoCliente",
                table: "Clientes");
        }
    }
}
