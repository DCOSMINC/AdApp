using Microsoft.EntityFrameworkCore.Migrations;

namespace AdData.Migrations
{
    public partial class CMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserIdVal",
                table: "Ads",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryIdVal",
                table: "Ads",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserIdVal",
                table: "Ads",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryIdVal",
                table: "Ads",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
