using Microsoft.EntityFrameworkCore.Migrations;

namespace CBT.DataModel.Migrations
{
    public partial class version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamOptions_ExamQuestions_ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.DropIndex(
                name: "IX_ExamOptions_ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.DropColumn(
                name: "QuestionChoice",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "ExamQuestionId",
                table: "ExamOptions");

            migrationBuilder.AddColumn<string>(
                name: "OptionA",
                table: "ExamQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionB",
                table: "ExamQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionC",
                table: "ExamQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionD",
                table: "ExamQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionE",
                table: "ExamQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionA",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "OptionB",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "OptionC",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "OptionD",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "OptionE",
                table: "ExamQuestions");

            migrationBuilder.AddColumn<bool>(
                name: "QuestionChoice",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: false);

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
    }
}
