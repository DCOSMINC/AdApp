using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class BMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryIdVal",
                table: "Ads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdVal",
                table: "Ads",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryIdVal",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UserIdVal",
                table: "Ads");
        }
    }
}
