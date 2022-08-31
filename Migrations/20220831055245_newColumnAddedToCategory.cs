using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMART.Migrations
{
    public partial class newColumnAddedToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Category",
                newName: "CategoryName");
        }
    }
}
