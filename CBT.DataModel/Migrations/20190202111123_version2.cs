using Microsoft.EntityFrameworkCore.Migrations;

namespace CBT.DataModel.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_ExamOptions_ExamOptionId",
                table: "ExamQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestions_ExamOptionId",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "ExamOptionId",
                table: "ExamQuestions");

            migrationBuilder.AddColumn<int>(
                name: "ExamQuestionId",
                table: "ExamOptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamOptions_ExamQuestionId",
                table: "ExamOptions",
                column: "ExamQuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamOptions_ExamQuestions_ExamQuestionId",
                table: "ExamOptions",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "ExamQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamOptions_ExamQuestions_ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.DropIndex(
                name: "IX_ExamOptions_ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.AddColumn<int>(
                name: "ExamOptionId",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamOptionId",
                table: "ExamQuestions",
                column: "ExamOptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_ExamOptions_ExamOptionId",
                table: "ExamQuestions",
                column: "ExamOptionId",
                principalTable: "ExamOptions",
                principalColumn: "ExamOptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
