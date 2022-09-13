using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMART.Migrations
{
    public partial class userTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserAccounts",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserAccounts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserAccounts",
                newName: "Username");
        }
    }
}
