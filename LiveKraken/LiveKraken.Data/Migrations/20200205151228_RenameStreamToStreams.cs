using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class RenameStreamToStreams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stream_Games_GameId",
                table: "Stream");

            migrationBuilder.DropForeignKey(
                name: "FK_Stream_Users_UserId",
                table: "Stream");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stream",
                table: "Stream");

            migrationBuilder.RenameTable(
                name: "Stream",
                newName: "Streams");

            migrationBuilder.RenameIndex(
                name: "IX_Stream_UserId",
                table: "Streams",
                newName: "IX_Streams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Stream_GameId",
                table: "Streams",
                newName: "IX_Streams_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streams",
                table: "Streams",
                column: "StreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Games_GameId",
                table: "Streams",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Users_UserId",
                table: "Streams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Games_GameId",
                table: "Streams");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Users_UserId",
                table: "Streams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streams",
                table: "Streams");

            migrationBuilder.RenameTable(
                name: "Streams",
                newName: "Stream");

            migrationBuilder.RenameIndex(
                name: "IX_Streams_UserId",
                table: "Stream",
                newName: "IX_Stream_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Streams_GameId",
                table: "Stream",
                newName: "IX_Stream_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stream",
                table: "Stream",
                column: "StreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stream_Games_GameId",
                table: "Stream",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stream_Users_UserId",
                table: "Stream",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
