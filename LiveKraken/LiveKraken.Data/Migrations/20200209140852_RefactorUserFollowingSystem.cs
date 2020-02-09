using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class RefactorUserFollowingSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Followers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Following",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "StreamKey",
                table: "Streams",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b7b5518d-4d88-42f9-a04a-e2efa33a969a"));

            migrationBuilder.CreateTable(
                name: "UserToUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FollowerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToUser", x => new { x.UserId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_UserToUser_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserToUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToUser_FollowerId",
                table: "UserToUser",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToUser");

            migrationBuilder.AddColumn<string>(
                name: "Followers",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Following",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StreamKey",
                table: "Streams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b7b5518d-4d88-42f9-a04a-e2efa33a969a"),
                oldClrType: typeof(Guid));
        }
    }
}
