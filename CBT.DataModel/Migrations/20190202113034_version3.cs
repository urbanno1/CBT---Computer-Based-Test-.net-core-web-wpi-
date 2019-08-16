using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBT.DataModel.Migrations
{
    public partial class version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExamOptions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExamOptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ExamOptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ExamOptions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ExamOptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ExamOptions");
        }
    }
}
