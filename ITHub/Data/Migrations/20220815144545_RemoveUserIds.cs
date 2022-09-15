using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHub.Data.Migrations
{
    public partial class RemoveUserIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
