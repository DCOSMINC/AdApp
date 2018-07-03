using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class CMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentValue",
                table: "Ads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentValue",
                table: "Ads");
        }
    }
}
