using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class BMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdVal",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdVal",
                table: "Comments");
        }
    }
}
