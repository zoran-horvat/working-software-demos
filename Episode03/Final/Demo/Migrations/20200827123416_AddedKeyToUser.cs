using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class AddedKeyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerKey",
                schema: "Content",
                table: "Products",
                nullable: false,
                defaultValue: "");

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
                value: "36E7A6B4-ACE8-477F-90EF-671A1A79D901");

            migrationBuilder.UpdateData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Key",
                value: "07FFAEA2-BBBE-4767-8FCF-D4B4A60F6B22");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Key",
                schema: "Authentication",
                table: "Users",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Key",
                schema: "Authentication",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OwnerKey",
                schema: "Content",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "Authentication",
                table: "Users");
        }
    }
}
