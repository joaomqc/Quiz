using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Infrastructure.Migrations
{
    public partial class AddExternalIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Username",
                schema: "usermanagement",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                schema: "usermanagement",
                table: "Users",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.CreateIndex(
                name: "Index_ExternalId",
                schema: "usermanagement",
                table: "Users",
                column: "ExternalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_ExternalId",
                schema: "usermanagement",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                schema: "usermanagement",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "Index_Username",
                schema: "usermanagement",
                table: "Users",
                column: "Username",
                unique: true);
        }
    }
}
