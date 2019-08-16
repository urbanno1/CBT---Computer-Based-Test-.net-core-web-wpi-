using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBT.DataModel.Migrations
{
    public partial class version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           


           

            migrationBuilder.CreateTable(
                name: "ExamOptions",
                columns: table => new
                {
                    ExamOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionA = table.Column<string>(nullable: true),
                    OptionB = table.Column<string>(nullable: true),
                    OptionC = table.Column<string>(nullable: true),
                    OptionD = table.Column<string>(nullable: true),
                    OptionE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamOptions", x => x.ExamOptionId);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    ExamQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionBody = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    QuestionChoice = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ExamTopicId = table.Column<int>(nullable: false),
                    ExamOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.ExamQuestionId);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_ExamOptions_ExamOptionId",
                        column: x => x.ExamOptionId,
                        principalTable: "ExamOptions",
                        principalColumn: "ExamOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_ExamTopics_ExamTopicId",
                        column: x => x.ExamTopicId,
                        principalTable: "ExamTopics",
                        principalColumn: "ExamTopicId",
                        onDelete: ReferentialAction.Cascade);
                });

           
           

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamOptionId",
                table: "ExamQuestions",
                column: "ExamOptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamTopicId",
                table: "ExamQuestions",
                column: "ExamTopicId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "ExamQuestions");

           

            migrationBuilder.DropTable(
                name: "ExamOptions");

        }
    }
}
