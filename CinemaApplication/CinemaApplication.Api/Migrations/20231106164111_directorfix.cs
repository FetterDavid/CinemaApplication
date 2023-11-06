using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApplication.Api.Migrations
{
    public partial class directorfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Directors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
