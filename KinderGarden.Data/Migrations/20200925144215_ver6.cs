using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarden.Data.Migrations
{
    public partial class ver6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KindergardenId",
                table: "Kids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kids_KindergardenId",
                table: "Kids",
                column: "KindergardenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Kindergardens_KindergardenId",
                table: "Kids",
                column: "KindergardenId",
                principalTable: "Kindergardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Kindergardens_KindergardenId",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Kids_KindergardenId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "KindergardenId",
                table: "Kids");
        }
    }
}
