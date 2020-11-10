using Microsoft.EntityFrameworkCore.Migrations;

namespace crosam.Data.Migrations
{
    public partial class MigracionLocation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
