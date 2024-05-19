using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnakeApplication.Data.Migrations
{
    public partial class MigrimiItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "items");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "items");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "items",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
