using Microsoft.EntityFrameworkCore.Migrations;

namespace Misc.Song.ShareClub.DataAccess.Migrations
{
    public partial class updatefileinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "fileSize",
                table: "fileInfos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "fileSize",
                table: "fileInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
