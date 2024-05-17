using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeApplication.Data.Migrations
{
    public partial class Migrimi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "players");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "players");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "players",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
