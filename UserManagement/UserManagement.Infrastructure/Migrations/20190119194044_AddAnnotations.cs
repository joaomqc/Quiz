using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Infrastructure.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "usermanagement",
                table: "Users",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "usermanagement",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "usermanagement",
                table: "Users",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "Index_Username",
                schema: "usermanagement",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Username",
                schema: "usermanagement",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "usermanagement",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "usermanagement",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "usermanagement",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 254);
        }
    }
}
