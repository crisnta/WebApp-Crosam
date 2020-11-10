using Microsoft.EntityFrameworkCore.Migrations;

namespace crosam.Data.Migrations
{
    public partial class MigracionLocation21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seeder",
                columns: table => new
                {
                    SeederID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationID = table.Column<int>(nullable: false),
                    SeederName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeder", x => x.SeederID);
                    table.ForeignKey(
                        name: "FK_Seeder_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seeder_LocationID",
                table: "Seeder",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seeder");
        }
    }
}
