using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarden.Data.Migrations
{
    public partial class ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Kindergardens_KindergardenId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Kid_Group_GroupId",
                table: "Kid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kid",
                table: "Kid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Kid");

            migrationBuilder.RenameTable(
                name: "Kid",
                newName: "Kids");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Kid_GroupId",
                table: "Kids",
                newName: "IX_Kids_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_KindergardenId",
                table: "Groups",
                newName: "IX_Groups_KindergardenId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AplicationDate",
                table: "Kids",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Kids",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Kids",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentsId",
                table: "Kids",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Kids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kids",
                table: "Kids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeTatko = table.Column<string>(nullable: true),
                    ImeMajka = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kids_ParentsId",
                table: "Kids",
                column: "ParentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Kindergardens_KindergardenId",
                table: "Groups",
                column: "KindergardenId",
                principalTable: "Kindergardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_Parents_ParentsId",
                table: "Kids",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Kindergardens_KindergardenId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Groups_GroupId",
                table: "Kids");

            migrationBuilder.DropForeignKey(
                name: "FK_Kids_Parents_ParentsId",
                table: "Kids");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kids",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Kids_ParentsId",
                table: "Kids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "AplicationDate",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Kids");

            migrationBuilder.RenameTable(
                name: "Kids",
                newName: "Kid");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Kids_GroupId",
                table: "Kid",
                newName: "IX_Kid_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_KindergardenId",
                table: "Group",
                newName: "IX_Group_KindergardenId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Kid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kid",
                table: "Kid",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Kindergardens_KindergardenId",
                table: "Group",
                column: "KindergardenId",
                principalTable: "Kindergardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kid_Group_GroupId",
                table: "Kid",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
