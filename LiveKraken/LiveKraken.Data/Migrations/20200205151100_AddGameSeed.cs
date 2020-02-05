using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class AddGameSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("010f4d5d-721e-429e-9ca9-324fb9b466f2"));

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[] { new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"), "", "https://pbs.twimg.com/profile_images/1049746840/blank_400x400.jpg", "" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"), "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("010f4d5d-721e-429e-9ca9-324fb9b466f2"), "user" });
        }
    }
}
