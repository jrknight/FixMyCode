using Microsoft.EntityFrameworkCore.Migrations;

namespace FixMyCode.Migrations
{
    public partial class reviewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_ReviewerId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_StudentId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_ReviewerId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_StudentId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "OriginalCode",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Responses");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Responses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FixedCode",
                table: "Responses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QueryId",
                table: "Responses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId1",
                table: "Responses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatWhy",
                table: "Responses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Queries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ReviewerId1",
                table: "Responses",
                column: "ReviewerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_ReviewId",
                table: "Queries",
                column: "ReviewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Queries_Responses_ReviewId",
                table: "Queries",
                column: "ReviewId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_ReviewerId1",
                table: "Responses",
                column: "ReviewerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queries_Responses_ReviewId",
                table: "Queries");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_ReviewerId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_ReviewerId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Queries_ReviewId",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "QueryId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "ReviewerId1",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "WhatWhy",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Queries");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "Responses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FixedCode",
                table: "Responses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "OriginalCode",
                table: "Responses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Responses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ReviewerId",
                table: "Responses",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_StudentId",
                table: "Responses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_ReviewerId",
                table: "Responses",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_StudentId",
                table: "Responses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
