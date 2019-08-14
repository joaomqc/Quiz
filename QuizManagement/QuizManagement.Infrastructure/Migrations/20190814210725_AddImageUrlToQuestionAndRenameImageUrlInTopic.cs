using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManagement.Infrastructure.Migrations
{
    public partial class AddImageUrlToQuestionAndRenameImageUrlInTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "quizmanagement",
                table: "Topics",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "quizmanagement",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "quizmanagement",
                table: "Quizzes");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "quizmanagement",
                table: "Quizzes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "quizmanagement",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                schema: "quizmanagement",
                table: "Topics",
                newName: "Url");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "quizmanagement",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "quizmanagement",
                table: "Quizzes");
        }
    }
}
