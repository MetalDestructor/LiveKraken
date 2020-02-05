using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class RoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("9ab9538a-9925-4fd6-89df-8e49ddd4daca"), "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9ab9538a-9925-4fd6-89df-8e49ddd4daca"));
        }
    }
}
