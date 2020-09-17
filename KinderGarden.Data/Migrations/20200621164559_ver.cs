using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarden.Data.Migrations
{
    public partial class ver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Kids",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Kids",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
