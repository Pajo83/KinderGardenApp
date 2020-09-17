using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarden.Data.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Parents_ParentsId",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Kids_ParentsId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Kids");

            migrationBuilder.AlterColumn<string>(
                name: "Municipality",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImeTatko",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImeMajka",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Parents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Kids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentId",
                table: "Kids",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Parents_ParentId",
                table: "Kids",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Parents_ParentId",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Kids_ParentId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Kids");

            migrationBuilder.AlterColumn<string>(
                name: "Municipality",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImeTatko",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImeMajka",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ParentsId",
                table: "Kids",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentsId",
                table: "Kids",
                column: "ParentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Parents_ParentsId",
                table: "Kids",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
