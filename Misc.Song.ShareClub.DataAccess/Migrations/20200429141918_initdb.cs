using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Misc.Song.ShareClub.DataAccess.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userInfos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    userPwd = table.Column<string>(nullable: true),
                    avatar = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userInfos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userLogs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    ipAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userLogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fileInfos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(nullable: true),
                    fileSize = table.Column<int>(nullable: false),
                    Userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_fileInfos_userInfos_Userid",
                        column: x => x.Userid,
                        principalTable: "userInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fileInfos_Userid",
                table: "fileInfos",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileInfos");

            migrationBuilder.DropTable(
                name: "userLogs");

            migrationBuilder.DropTable(
                name: "userInfos");
        }
    }
}
