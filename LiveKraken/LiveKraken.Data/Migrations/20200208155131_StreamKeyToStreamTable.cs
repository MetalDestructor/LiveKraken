using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveKraken.Data.Migrations
{
    public partial class StreamKeyToStreamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Streams",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                table: "Streams",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Streams",
                nullable: false,
                defaultValue: "https://www.tourniagara.com/wp-content/uploads/2014/10/default-img.gif",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "Streams",
                nullable: false,
                defaultValue: new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "StreamKey",
                table: "Streams",
                nullable: false,
                defaultValue: new Guid("b7b5518d-4d88-42f9-a04a-e2efa33a969a"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamKey",
                table: "Streams");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("d5fe4106-e7c1-493c-8118-02298e96e2a8"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Streams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                table: "Streams",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Streams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValue: "https://www.tourniagara.com/wp-content/uploads/2014/10/default-img.gif");

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "Streams",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8e99bcbb-84e1-4957-98cf-eb5c3a186296"));
        }
    }
}
