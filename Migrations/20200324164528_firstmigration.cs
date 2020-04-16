using Microsoft.EntityFrameworkCore.Migrations;

namespace motoroutes.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_rides_Users_UserId",
                table: "rides");

            migrationBuilder.DropIndex(
                name: "IX_rides_UserId",
                table: "rides");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "rides");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "comments");

            migrationBuilder.AddColumn<string>(
                name: "commentcreator",
                table: "comments",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commentcreator",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "rides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_rides_UserId",
                table: "rides",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rides_Users_UserId",
                table: "rides",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
