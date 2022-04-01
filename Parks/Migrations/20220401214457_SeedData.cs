using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "varchar(2) CHARACTER SET utf8mb4", maxLength: 2, nullable: false),
                    Swimming = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Hiking = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "City", "Hiking", "Name", "Size", "State", "Swimming" },
                values: new object[,]
                {
                    { 1, "Post Falls", true, "Q’emiln Park", 508, "ID", true },
                    { 2, "Spokane", true, "People's Park", 258, "WA", true },
                    { 3, "Gresham", true, "Oneonta Park", 106, "OR", false },
                    { 4, "Springfield", true, "Blair Park", 766, "MA", false },
                    { 5, "Newport", true, "Agate Beach", 1405, "OR", true },
                    { 6, "Gresham", true, "Ainsworth", 1405, "OR", false },
                    { 7, "Triangle Lake", true, "Alderwood Wayside", 895, "OR", true },
                    { 8, "Hood River", true, "Angel's Rest", 2719, "OR", true },
                    { 9, "Portland", true, "Banks Vernonia Trail", 2719, "OR", false },
                    { 10, "Spokane", false, "Riverfront Park", 595, "WA", false },
                    { 11, "Pendleton", true, "Battle Mountain", 367, "OR", false },
                    { 12, "Portland", true, "Bald Peak", 246, "OR", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
