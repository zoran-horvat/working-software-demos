using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedUserKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "Authentication",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Key",
                value: "B1417667-2221-4CC0-BF9B-58644DD3FB53");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: "41AB23B3-3F24-4786-AAAB-ED296605A66F");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Authentication",
                table: "Users");
        }
    }
}
