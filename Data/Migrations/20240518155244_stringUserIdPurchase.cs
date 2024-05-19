using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeApplication.Data.Migrations
{
    public partial class stringUserIdPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_AspNetUsers_UserId1",
                table: "purchases");

            migrationBuilder.DropIndex(
                name: "IX_purchases_UserId1",
                table: "purchases");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "purchases");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "purchases",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchases_AspNetUsers_UserId",
                table: "purchases");

            migrationBuilder.DropIndex(
                name: "IX_purchases_UserId",
                table: "purchases");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "purchases",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "purchases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchases_UserId1",
                table: "purchases",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_purchases_AspNetUsers_UserId1",
                table: "purchases",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
