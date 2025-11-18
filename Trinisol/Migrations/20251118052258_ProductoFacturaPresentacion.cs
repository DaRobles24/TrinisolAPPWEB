using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinisol.Migrations
{
    /// <inheritdoc />
    public partial class ProductoFacturaPresentacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PresentacionId",
                table: "ProductosFacturados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosFacturados_PresentacionId",
                table: "ProductosFacturados",
                column: "PresentacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosFacturados_Presentaciones_PresentacionId",
                table: "ProductosFacturados",
                column: "PresentacionId",
                principalTable: "Presentaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosFacturados_Presentaciones_PresentacionId",
                table: "ProductosFacturados");

            migrationBuilder.DropIndex(
                name: "IX_ProductosFacturados_PresentacionId",
                table: "ProductosFacturados");

            migrationBuilder.DropColumn(
                name: "PresentacionId",
                table: "ProductosFacturados");
        }
    }
}
