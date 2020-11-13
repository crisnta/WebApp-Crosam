using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crosam.Data.Migrations
{
    public partial class MigracionesEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BouyType",
                columns: table => new
                {
                    BouyTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BouyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouyType", x => x.BouyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CuelgaType",
                columns: table => new
                {
                    CuelgaTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuelgaTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuelgaType", x => x.CuelgaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Seed",
                columns: table => new
                {
                    SeedId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeedSize = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seed", x => x.SeedId);
                });

            migrationBuilder.CreateTable(
                name: "Substratum",
                columns: table => new
                {
                    SubstratumId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubstratumName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substratum", x => x.SubstratumId);
                });

            migrationBuilder.CreateTable(
                name: "Cuelga",
                columns: table => new
                {
                    CuelgaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuelgaTypeId = table.Column<int>(nullable: false),
                    CuelgaLenght = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuelga", x => x.CuelgaId);
                    table.ForeignKey(
                        name: "FK_Cuelga_CuelgaType_CuelgaTypeId",
                        column: x => x.CuelgaTypeId,
                        principalTable: "CuelgaType",
                        principalColumn: "CuelgaTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sow",
                columns: table => new
                {
                    SowId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuelgaTypeId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    SeederId = table.Column<int>(nullable: false),
                    SubstratumId = table.Column<int>(nullable: false),
                    CuelgaId = table.Column<int>(nullable: false),
                    SeedId = table.Column<int>(nullable: false),
                    BouyTypeId = table.Column<int>(nullable: false),
                    Linea = table.Column<int>(nullable: false),
                    CantidadColgado = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sow", x => x.SowId);
                    table.ForeignKey(
                        name: "FK_Sow_BouyType_BouyTypeId",
                        column: x => x.BouyTypeId,
                        principalTable: "BouyType",
                        principalColumn: "BouyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_Cuelga_CuelgaId",
                        column: x => x.CuelgaId,
                        principalTable: "Cuelga",
                        principalColumn: "CuelgaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_CuelgaType_CuelgaTypeId",
                        column: x => x.CuelgaTypeId,
                        principalTable: "CuelgaType",
                        principalColumn: "CuelgaTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_Seed_SeedId",
                        column: x => x.SeedId,
                        principalTable: "Seed",
                        principalColumn: "SeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_Seeder_SeederId",
                        column: x => x.SeederId,
                        principalTable: "Seeder",
                        principalColumn: "SeederID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_Substratum_SubstratumId",
                        column: x => x.SubstratumId,
                        principalTable: "Substratum",
                        principalColumn: "SubstratumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sow_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuelga_CuelgaTypeId",
                table: "Cuelga",
                column: "CuelgaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_BouyTypeId",
                table: "Sow",
                column: "BouyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_CuelgaId",
                table: "Sow",
                column: "CuelgaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_CuelgaTypeId",
                table: "Sow",
                column: "CuelgaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_SeedId",
                table: "Sow",
                column: "SeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_SeederId",
                table: "Sow",
                column: "SeederId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_SubstratumId",
                table: "Sow",
                column: "SubstratumId");

            migrationBuilder.CreateIndex(
                name: "IX_Sow_SupplierId",
                table: "Sow",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sow");

            migrationBuilder.DropTable(
                name: "BouyType");

            migrationBuilder.DropTable(
                name: "Cuelga");

            migrationBuilder.DropTable(
                name: "Seed");

            migrationBuilder.DropTable(
                name: "Substratum");

            migrationBuilder.DropTable(
                name: "CuelgaType");
        }
    }
}
