using Microsoft.EntityFrameworkCore.Migrations;

namespace FixMyCode.Migrations
{
    public partial class QueryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Queries",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Queries",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Queries");
        }
    }
}
