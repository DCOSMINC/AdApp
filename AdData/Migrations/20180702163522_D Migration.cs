using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class DMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdIdVal",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserIdVal",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdIdVal",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdVal",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
