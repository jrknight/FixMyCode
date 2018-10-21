using Microsoft.EntityFrameworkCore.Migrations;

namespace FixMyCode.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FixedCode",
                table: "Responses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalCode",
                table: "Responses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Queries",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FixedCode",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "OriginalCode",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Queries");
        }
    }
}
