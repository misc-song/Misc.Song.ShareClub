using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Misc.Song.ShareClub.DataAccess.Migrations
{
    public partial class addInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "userLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "userLogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageView",
                table: "fileInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "downloadCount",
                table: "fileInfos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "userLogs");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "userLogs");

            migrationBuilder.DropColumn(
                name: "PageView",
                table: "fileInfos");

            migrationBuilder.DropColumn(
                name: "downloadCount",
                table: "fileInfos");
        }
    }
}
