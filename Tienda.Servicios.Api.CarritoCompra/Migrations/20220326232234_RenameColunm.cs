using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.Servicios.Api.CarritoCompra.Migrations
{
    public partial class RenameColunm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoSeleccionado",
                table: "CarritoSesionDetalles");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoSeleccionadoId",
                table: "CarritoSesionDetalles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoSeleccionadoId",
                table: "CarritoSesionDetalles");

            migrationBuilder.AddColumn<string>(
                name: "ProductoSeleccionado",
                table: "CarritoSesionDetalles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
