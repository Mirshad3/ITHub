using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITHub.Data.Migrations
{
    public partial class appliedJobswithIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "jobTechnologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cvDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    PublishedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appliedJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CvId = table.Column<int>(type: "int", nullable: false),
                    ApplicationState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jobAppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appliedJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appliedJobs_cvDatas_CvId",
                        column: x => x.CvId,
                        principalTable: "cvDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appliedJobs_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "img/TechLogo/HTML.png");

            migrationBuilder.UpdateData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "img/TechLogo/net.png");

            migrationBuilder.UpdateData(
                table: "jobTechnologies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "img/TechLogo/node.png");

            migrationBuilder.CreateIndex(
                name: "IX_appliedJobs_CvId",
                table: "appliedJobs",
                column: "CvId");

            migrationBuilder.CreateIndex(
                name: "IX_appliedJobs_JobId",
                table: "appliedJobs",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appliedJobs");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "cvDatas");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "jobTechnologies");
        }
    }
}
