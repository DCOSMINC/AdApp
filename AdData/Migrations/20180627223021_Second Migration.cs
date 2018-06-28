using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PostDate",
                table: "Ads",
                newName: "AddDate");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Ads",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ads",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "Ads",
                newName: "PostDate");
        }
    }
}
