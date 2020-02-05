using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class AddStreamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("495ac6a6-7b7f-449f-ac13-98a0cc4f08d5"));

            migrationBuilder.AddColumn<Guid>(
                name: "StreamId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Stream",
                columns: table => new
                {
                    StreamId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsOnline = table.Column<bool>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stream", x => x.StreamId);
                    table.ForeignKey(
                        name: "FK_Stream_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stream_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("010f4d5d-721e-429e-9ca9-324fb9b466f2"), "user" });

            migrationBuilder.CreateIndex(
                name: "IX_Stream_GameId",
                table: "Stream",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Stream_UserId",
                table: "Stream",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stream");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("010f4d5d-721e-429e-9ca9-324fb9b466f2"));

            migrationBuilder.DropColumn(
                name: "StreamId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("495ac6a6-7b7f-449f-ac13-98a0cc4f08d5"), "user" });
        }
    }
}
