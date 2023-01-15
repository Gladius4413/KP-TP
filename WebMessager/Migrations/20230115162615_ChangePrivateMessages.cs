using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMessager.Migrations
{
    public partial class ChangePrivateMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_User_UserId",
                table: "PrivateMessage");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PrivateMessage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserFromId",
                table: "PrivateMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserToId",
                table: "PrivateMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessage_UserFromId",
                table: "PrivateMessage",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessage_UserToId",
                table: "PrivateMessage",
                column: "UserToId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_User_UserFromId",
                table: "PrivateMessage",
                column: "UserFromId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_User_UserId",
                table: "PrivateMessage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_User_UserToId",
                table: "PrivateMessage",
                column: "UserToId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_User_UserFromId",
                table: "PrivateMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_User_UserId",
                table: "PrivateMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateMessage_User_UserToId",
                table: "PrivateMessage");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessage_UserFromId",
                table: "PrivateMessage");

            migrationBuilder.DropIndex(
                name: "IX_PrivateMessage_UserToId",
                table: "PrivateMessage");

            migrationBuilder.DropColumn(
                name: "UserFromId",
                table: "PrivateMessage");

            migrationBuilder.DropColumn(
                name: "UserToId",
                table: "PrivateMessage");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "PrivateMessage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateMessage_User_UserId",
                table: "PrivateMessage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
