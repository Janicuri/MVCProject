using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeApplication.Data.Migrations
{
    public partial class UpdatedPurchasesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_AspNetUsers_UserId",
                table: "purchases");

            migrationBuilder.DropIndex(
                name: "IX_purchases_UserId",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "purchases");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_purchases_PlayerId",
                table: "purchases",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_players_PlayerId",
                table: "purchases",
                column: "PlayerId",
                principalTable: "players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_players_PlayerId",
                table: "purchases");

            migrationBuilder.DropIndex(
                name: "IX_purchases_PlayerId",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "purchases");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "purchases",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_UserId",
                table: "purchases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_AspNetUsers_UserId",
                table: "purchases",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
