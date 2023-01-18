using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMessager.Migrations
{
    public partial class ChangeGroupChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GroupMessageId",
                table: "GroupChat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "GroupChat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "GroupChat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupMessageId",
                table: "GroupChat");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupChat");

            migrationBuilder.DropColumn(
                name: "name",
                table: "GroupChat");
        }
    }
}
