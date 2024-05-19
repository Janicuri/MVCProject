using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeApplication.Data.Migrations
{
    public partial class playerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bucks",
                table: "players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bucks",
                table: "players");
        }
    }
}
