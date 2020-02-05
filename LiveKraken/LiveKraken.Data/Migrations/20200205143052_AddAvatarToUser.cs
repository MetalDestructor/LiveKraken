using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class AddAvatarToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8bd6aba-9133-404e-b51f-805baad9b6e2"));

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("495ac6a6-7b7f-449f-ac13-98a0cc4f08d5"), "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("495ac6a6-7b7f-449f-ac13-98a0cc4f08d5"));

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("a8bd6aba-9133-404e-b51f-805baad9b6e2"), "user" });
        }
    }
}
