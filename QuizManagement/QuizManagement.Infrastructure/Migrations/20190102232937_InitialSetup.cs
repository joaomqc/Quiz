using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace QuizManagement.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "quizmanagement");

            migrationBuilder.CreateTable(
                name: "Topics",
                schema: "quizmanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                schema: "quizmanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false),
                    CreationTimestamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Topics_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "quizmanagement",
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "quizmanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: false),
                    CreationTimestamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalSchema: "quizmanagement",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "quizmanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: false),
                    IsMultipleChoice = table.Column<bool>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalSchema: "quizmanagement",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                schema: "quizmanagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "quizmanagement",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                schema: "quizmanagement",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuizId",
                schema: "quizmanagement",
                table: "Comments",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                schema: "quizmanagement",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TopicId",
                schema: "quizmanagement",
                table: "Quizzes",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers",
                schema: "quizmanagement");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "quizmanagement");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "quizmanagement");

            migrationBuilder.DropTable(
                name: "Quizzes",
                schema: "quizmanagement");

            migrationBuilder.DropTable(
                name: "Topics",
                schema: "quizmanagement");
        }
    }
}
