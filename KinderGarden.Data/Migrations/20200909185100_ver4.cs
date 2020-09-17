using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarden.Data.Migrations
{
    public partial class ver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");
        }
    }
}
