using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Misc.Song.ShareClub.DataAccess.Migrations
{
    public partial class AddFileType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FTypeid",
                table: "fileInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadTime",
                table: "fileInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "fileTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    typeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileTypes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fileInfos_FTypeid",
                table: "fileInfos",
                column: "FTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_fileInfos_fileTypes_FTypeid",
                table: "fileInfos",
                column: "FTypeid",
                principalTable: "fileTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileInfos_fileTypes_FTypeid",
                table: "fileInfos");

            migrationBuilder.DropTable(
                name: "fileTypes");

            migrationBuilder.DropIndex(
                name: "IX_fileInfos_FTypeid",
                table: "fileInfos");

            migrationBuilder.DropColumn(
                name: "FTypeid",
                table: "fileInfos");

            migrationBuilder.DropColumn(
                name: "UploadTime",
                table: "fileInfos");
        }
    }
}
