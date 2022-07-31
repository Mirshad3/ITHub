using Microsoft.EntityFrameworkCore.Migrations;

namespace ITHub.Data.Migrations
{
    public partial class filterChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "jobTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BriefDescription",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceLevelId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPegged",
                table: "jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "JobFunctionId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobImageId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemunerationId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemunerationMax",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemunerationMin",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnologiesId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkmodeId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ComanyLogoImagePath",
                table: "companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "currencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "datePosteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datePosteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "experienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobTechnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "remuneration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remuneration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "remunerationRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remunerationRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "jobWithExperienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobWithExperienceLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobWithExperienceLevels_experienceLevels_ExperienceLevelId",
                        column: x => x.ExperienceLevelId,
                        principalTable: "experienceLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobWithExperienceLevels_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobWithFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobFunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobWithFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobWithFunction_jobFunction_JobFunctionId",
                        column: x => x.JobFunctionId,
                        principalTable: "jobFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobWithFunction_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobWithTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobTechnologiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobWithTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobWithTechnologies_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobWithTechnologies_jobTechnologies_JobTechnologiesId",
                        column: x => x.JobTechnologiesId,
                        principalTable: "jobTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_JobType",
                table: "jobs",
                column: "JobType");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_Location",
                table: "jobs",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithExperienceLevels_ExperienceLevelId",
                table: "jobWithExperienceLevels",
                column: "ExperienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithExperienceLevels_JobId",
                table: "jobWithExperienceLevels",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithFunction_JobFunctionId",
                table: "jobWithFunction",
                column: "JobFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithFunction_JobId",
                table: "jobWithFunction",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithTechnologies_JobId",
                table: "jobWithTechnologies",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_jobWithTechnologies_JobTechnologiesId",
                table: "jobWithTechnologies",
                column: "JobTechnologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_companies_CompanyId",
                table: "jobs",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_jobTypes_JobType",
                table: "jobs",
                column: "JobType",
                principalTable: "jobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_locations_Location",
                table: "jobs",
                column: "Location",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_companies_CompanyId",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_jobTypes_JobType",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_locations_Location",
                table: "jobs");

            migrationBuilder.DropTable(
                name: "currencyTypes");

            migrationBuilder.DropTable(
                name: "datePosteds");

            migrationBuilder.DropTable(
                name: "jobWithExperienceLevels");

            migrationBuilder.DropTable(
                name: "jobWithFunction");

            migrationBuilder.DropTable(
                name: "jobWithTechnologies");

            migrationBuilder.DropTable(
                name: "remuneration");

            migrationBuilder.DropTable(
                name: "remunerationRanges");

            migrationBuilder.DropTable(
                name: "workModes");

            migrationBuilder.DropTable(
                name: "experienceLevels");

            migrationBuilder.DropTable(
                name: "jobFunction");

            migrationBuilder.DropTable(
                name: "jobTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_JobType",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_Location",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "jobTypes");

            migrationBuilder.DropColumn(
                name: "BriefDescription",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ExperienceLevelId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "IsPegged",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobFunctionId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "JobImageId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "RemunerationId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "RemunerationMax",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "RemunerationMin",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "TechnologiesId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "WorkmodeId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ComanyLogoImagePath",
                table: "companies");
        }
    }
}
