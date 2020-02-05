using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class AddImageToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9ab9538a-9925-4fd6-89df-8e49ddd4daca"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Games",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("a8bd6aba-9133-404e-b51f-805baad9b6e2"), "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8bd6aba-9133-404e-b51f-805baad9b6e2"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Games");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("9ab9538a-9925-4fd6-89df-8e49ddd4daca"), "user" });
        }
    }
}
