using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentaServices.Migrations
{
    public partial class inicio12aq34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(nullable: true),
                    PorcentajeImpuesto = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalles",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactura = table.Column<int>(nullable: false),
                    IdArticulo = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalles", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Articulos_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Factura_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdArticulo",
                table: "FacturaDetalles",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_IdFactura",
                table: "FacturaDetalles",
                column: "IdFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaDetalles");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Factura");
        }
    }
}
