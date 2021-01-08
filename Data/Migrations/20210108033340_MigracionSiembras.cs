using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crosam.Data.Migrations
{
    public partial class MigracionSiembras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioFlete",
                columns: table => new
                {
                    ServicioFleteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServicioFleteName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioFlete", x => x.ServicioFleteId);
                });

            migrationBuilder.CreateTable(
                name: "Siembras",
                columns: table => new
                {
                    SiembraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServicioFleteId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    NroGuia = table.Column<int>(nullable: false),
                    Recepcion = table.Column<int>(nullable: false),
                    ValorUnidad = table.Column<decimal>(nullable: false),
                    GastoSemilla = table.Column<decimal>(nullable: false),
                    GastoFlete = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siembras", x => x.SiembraId);
                    table.ForeignKey(
                        name: "FK_Siembras_ServicioFlete_ServicioFleteId",
                        column: x => x.ServicioFleteId,
                        principalTable: "ServicioFlete",
                        principalColumn: "ServicioFleteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siembras_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siembras_ServicioFleteId",
                table: "Siembras",
                column: "ServicioFleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Siembras_SupplierId",
                table: "Siembras",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siembras");

            migrationBuilder.DropTable(
                name: "ServicioFlete");
        }
    }
}
